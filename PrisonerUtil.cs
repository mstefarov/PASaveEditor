using System;
using System.Collections.Generic;
using System.Linq;
using PASaveEditor.FileModel;

namespace PASaveEditor {
    internal static class PrisonerUtil {

        static readonly Dictionary<string, string> CategoryNames = new Dictionary<string, string> {
            { "Protected", "Protective Custody" },
            { "MinSec", "Minimum Security" },
            { "Normal", "Normal Security" },
            { "MaxSec", "Maximum Security" },
            { "SuperMax", "SuperMax" }
        };


        public static string CategoryIndexToName(int index) {
            return CategoryNames.Keys.ToArray()[index];
        }


        public static int CategoryNameToIndex(string catName) {
            return Array.IndexOf(CategoryNames.Keys.ToArray(), catName);
        }


        public static int[] FindPrisoners(Prison prison, Predicate<Prisoner> predicate) {
            return prison.Objects.Prisoners.Values
                         .Where(prisoner => predicate(prisoner))
                         .Select(prisoner => prisoner.Id)
                         .ToArray();
        }


        public static int Release(Prison prison, Predicate<Prisoner> predicate) {
            int[] idsToRemove = FindPrisoners(prison, predicate);
            foreach (int id in idsToRemove) {
                ReleasePrisoner(prison, id);
            }
            return idsToRemove.Length;
        }


        public static void ReleasePrisoner(Prison prison, int id) {
            prison.Objects.Prisoners.Remove(id);
            prison.Contraband.Child.Prisoners.Remove(id);
            prison.Informants.Child.Prisoners.RemoveAll(informant => informant.PrisonerId == id);
            prison.Misconduct.Reports.Reports.Remove(id);
            prison.Penalties.Child.PenaltyList.Remove(id);
            foreach (ReformProgram program in prison.Reform.Programs.Programs) {
                program.Students.Students.Remove(id);
            }
            // TODO Diggers
            prison.Victory.Child.Log.RemoveAll(entry => entry.PrisonerId == id);
        }
    }
}