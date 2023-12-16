import { useState } from "react"
import UserItem from "../../models/UserItem";
import { useSearchService } from "../../services/api/useSearchService";
import ItemGrid from "../ItemGrid/ItemGrid";

/** component containing a basic search bar and results grid */
export default function Search() {
    const [data, setData] = useState<UserItem[]>([]); // from the API
    const [searchQuery, setSearchQuery] = useState<string>(''); 
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [errorText, setErrorText] = useState<string>(''); // error / warning display for user
    const searchService = useSearchService();

    // triggered when user clicks search button
    const applySearch = async () => {
        setErrorText('');
        if (!searchQuery || !searchQuery.trim()) {
            setIsLoading(false);
            setErrorText ("search input must not be empty");
            return;
        }

        if (!searchQuery.match(/^[A-Za-z0-9 ]+$/)) {
            setIsLoading(false);
            // this is slightly awkward because it prevents searching specific email addresses.
            // if I had more time, I'd do better filtering here
            setErrorText ("search input must only contain letters, numbers and spaces");
            return;
        }

        setIsLoading(true);
        try {
            const data = await searchService.search(searchQuery);
            setData(data);
        } catch (e) {
            console.error(e);
            // todo: extract error message
            setErrorText("An internal error has been logged.");
        } finally {
            setIsLoading(false);
        }

    }
    const errorDisplay = errorText ? <p>{errorText}</p> : <></>;
    const loader = isLoading ? <p>Loading...</p> : <></>;

    return <div>
        <p>
            <label htmlFor="search" >Search:</label> 
            <input type='text' id="search" data-testid="search-input" value={searchQuery} onChange={(e) => setSearchQuery(e.target.value)} />
            <input type='button' value='search!' onClick={applySearch} />
        </p>
        {errorDisplay}
        {loader}
        <ItemGrid items={data}></ItemGrid>
        
    </div>
}