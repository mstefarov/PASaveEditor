using System;
using System.Linq;
using FileModel;

namespace PASaveEditor {
    internal static class PrisonerUtil {
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
            prison.Contraband.Prisoners.Prisoners.Remove(id);
            prison.Informants.Informants2.Prisoners.RemoveAll(informant => informant.PrisonerId == id);
            prison.Misconduct.Reports.Reports.Remove(id);
            prison.Penalties.Penalties2.Penalties.Remove(id);
            foreach (ReformProgram program in prison.Reform.Programs.Programs) {
                program.Students.Students.Remove(id);
            }
            // TODO Diggers
            prison.Victory.Log.Log.RemoveAll(entry => entry.PrisonerId == id);
        }
    }
}