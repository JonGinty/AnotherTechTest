

import {render, fireEvent, act, waitFor} from '@testing-library/react';
import Search from './Search';

jest.mock("../../services/api/useSearchService", () => ({
    useSearchService: () => ({
        search: (_: string) => Promise.reject("unknown error")
    })
}));

test('displays error message when network request fails', async () => {
    const { queryByText, getByText, getByTestId } = render(<Search></Search>)
    expect(queryByText("Kubu")).toBeNull()
    expect(queryByText("clongfu")).toBeNull();

    act(() => {
        fireEvent.change(getByTestId("search-input"), {target: {value: "foo"}});
        fireEvent.click(getByText("search!"));
    })

    expect(queryByText("search input must not be empty")).toBeNull();

    await waitFor(() => {
        expect(queryByText("An internal error has been logged")).toBeNull();
    })
})
