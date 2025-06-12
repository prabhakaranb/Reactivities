import { DateArg, format } from "date-fns";

export function formatDate(date: DateArg) {
  return format(new Date(date), 'MMMM dd, yyyy');
}
