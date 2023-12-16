import UserItem from "../../models/UserItem";
import useApiClient from "./useApiClient";

export function useSearchService(): {
  search: (searchQuery: string) => Promise<UserItem[]>;
} {
  const client = useApiClient();
  return {
    search: async (searchQuery: string) =>
      (await client.get(`search/${searchQuery}`)).data,
  };
}
