import { test, expect, Page } from '@playwright/test';
import { appPath } from '../test.config';


async function doSearch(page: Page, query: string) {
    await page.goto(appPath);
    const search = await page.getByLabel("Search:");
    await search.fill(query);
    await page.getByText("Search!").click();
}

test('James Kubu scenario', async ({page}) => {
    await doSearch(page, "James Kubu");
    await expect(page.getByText("hkubu7@craigslist.org")).toBeVisible();
})

test('empty search scenario', async ({page}) => {
    await doSearch(page, "");
    await expect(page.getByText("search input must not be empty")).toBeVisible();
})