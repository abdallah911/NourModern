# Index Page Enhancement — Design

**Date:** 2026-06-11
**Scope:** `NourModern/Views/Home/Index.cshtml` only. No controller, model, or routing changes.

## Goal

Modernize the nursery application form page (حضانة نور الحديثة) visually and add proper
client-side validation with Arabic feedback, replacing the bare Bootstrap 4 + jQuery page.

## Approach (approved)

Upgrade to **Bootstrap 5.3 RTL** (CDN `bootstrap.rtl.min.css` + JS bundle). Replace jQuery
AJAX with vanilla JS `fetch()`. Use the **Tajawal** Arabic font from Google Fonts.

## Visual design

- Soft warm gradient page background (nursery-friendly, replacing flat `#f0f8ff`).
- Centered card: rounded corners, soft shadow.
- Header: `Sun2.jpg` logo in a circular frame, nursery name, short subtitle.
- Inputs: Bootstrap 5 `form-floating` floating labels.
- Full-width gradient submit button with hover/press feedback.
- Responsive on mobile.

## Validation (Arabic inline messages via `invalid-feedback`)

| Field | Rule |
|---|---|
| `fullName` | required, at least 2 words |
| `MatherName` | required |
| `KidId` | exactly 14 digits (Egyptian national ID) |
| `age` | integer 1–6 |
| `phone` | Egyptian mobile: `01` + 9 digits |

Validation runs on blur and on submit; first invalid field receives focus.

## Submit UX

- Button shows spinner + "جاري الإرسال..." while the request is in flight; button disabled.
- Success/error rendered as a dismissible Bootstrap alert inside the card (no `alert()`).
- Form resets and validation state clears on success.

## Compatibility constraints

- Field `name` attributes unchanged: `applicationType`, `fullName`, `MatherName`, `KidId`, `age`, `phone`.
- POST target unchanged: `/Home/SendEmail`, form-urlencoded body.
- Response contract unchanged: JSON `{ success: bool, error?: string }`.

## Testing

Build the project (`dotnet build`) and verify the page renders and submits in a browser run.
