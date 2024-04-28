import { test, expect } from "@playwright/test";
import { signInPageTestKeys } from "./index.js";
import { get_test_context } from "$configuration/test";
import { get_pw_key_selector } from "$utils/testing-helpers";

const context = get_test_context();

test("form loads", async ({ page }) => {
  page.goto("/sign-in");
  const form = page.locator(get_pw_key_selector(signInPageTestKeys.signInForm));
  expect(form.isVisible()).toBeTruthy();
});
