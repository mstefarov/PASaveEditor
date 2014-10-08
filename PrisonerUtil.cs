using System;
using System.Collections.Generic;
using System.Linq;
using PASaveEditor.FileModel;

namespace PASaveEditor {
    internal static class PrisonerUtil {
        // Names as they appear in the savegame are different from displayed names.
        static readonly Dictionary<string, string> CategoryNames = new Dictionary<string, string> {
            { "Protected", "Protective Custody" },
            { "MinSec", "Minimum Security" },
            { "Normal", "Normal Security" },
            { "MaxSec", "Maximum Security" },
            { "SuperMax", "SuperMax" }
        };


        // Converts short in-savegame name to index (0-4)
        public static string CategoryIndexToName(int index) {
            return CategoryNames.Keys.ToArray()[index];
        }


        // Converts index (0-4) to short in-savegame name
        public static int CategoryNameToIndex(string catName) {
            return Array.IndexOf(CategoryNames.Keys.ToArray(), catName);
        }


        // Returns a list of IDs of all prisoners who match the given predicate
        public static int[] FindPrisoners(Prison prison, Predicate<Prisoner> predicate) {
            return prison.Objects.Prisoners.Values
                         .Where(prisoner => predicate(prisoner))
                         .Select(prisoner => prisoner.Id)
                         .ToArray();
        }


        // Releases (eliminates) all prisoners who match the given predicate
        public static int Release(Prison prison, Predicate<Prisoner> predicate) {
            int[] idsToRemove = FindPrisoners(prison, predicate);
            foreach (int id in idsToRemove) {
                ReleasePrisoner(prison, id);
            }
            return idsToRemove.Length;
        }


        // Releases (eliminates) a single prisoner, by ID
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


        static Dictionary<int, string> UnnamedPrisoners = new Dictionary<int, string> {
            { 93446, "SoulCake" },
            { 94805, "BrawnyFanta" },
            { 95177, "Neotin" },
            { 111475, "Squirrel" },
            { 114697, "DarkKnightPyro" },
            { 114969, "The Kracksquatch" },
            { 118793, "The Joker" },
            { 124835, "Heisenberg" },
            { 127230, "TotmasterT" },
            { 136059, "konflakes" }
        };


        public static string NamePrisoner(Prisoner prisoner) {
            string nickName;
            if (UnnamedPrisoners.TryGetValue(prisoner.Bio.Nitg, out nickName)) {
                // Fix for nameless prisoners
                return '"' + nickName + '"';
            } else {
                return prisoner.Bio.Forname + " " + prisoner.Bio.Surname;
            }
        }
    }
}