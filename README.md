# NRatings
The AI ratings tool for NASCAR Racing 2003 Season (NR2003)

## What is NRatings
A tool that allows you to manipulate your NASCAR Racing 2003 AI car ratings.

Following functionalities are offered:

- Fetch data from real-life racing results and apply it to your selected AI carset
- The real data is mapped to your carset automatically (by driver name or number, or a combination of these)
- The mapping can be manually overridden
- NRatings comes with a few built-in formulas to calculate the ratings
- You can extend NRatings by creating your own formulas, or use formulas developed by other community users
- Some functionalities are offered to apply bulk modifications to ratings (multiply by x, randomize, ...)
- Compatible with any mod (Cup, GNS, Trucks, ...)
- Built-in roster management

## System Requirements
- A Windows based PC with Windows 7 SP1, Windows 8.1 or Windows 10 (recommended)
- Of course, the game NASCAR Racing 2003 Season itself
- The Microsoft .NET Framework 4.7.2 or higher
- The Edge WebView2 Runtime (you will be prompted in the app if you don't have it): https://go.microsoft.com/fwlink/p/?LinkId=2124703

## Credits

NRatings couldn't exist without contribution from these individuals and communities:

- https://racing-reference.info for providing the racing stats
- https://www.heliohost.org for providing the free hosting space for the backend. Please seriously consider donating to these guys if you like NRatings and use it often
- Following authors for providing the formulas that come embedded with the application:
  - MasGrafx (S10Man / OmegaSeven)
  - Dennis Grebe
  - Pbfoot
  - Snyderart
  - Rupe

## Download

[Click here to download the latest executable version](https://nratings.heliohost.org/download/client/NRatings.Client.application)

Since v5.1.0, it is now again required to log in when you want to use the real life racing data feature. This was re-introduced to protect the backend racing data API from being abused. The signup/login process is now however completely integrated in the application itself, and you can use social logins. However please note that earlier accounts (pre v5) will no longer work. You'll need to sign up for a new one, but you can reuse the same email address you used for the pre v5 version. However you are encouraged to use one of the social login options presented to you in the login screen. 

### IMPORTANT: if you still have a version prior to v5.0.0 of NRatings installed on your machine, first uninstall it (via Windows "Add or remove programs") before installing the newest version from here.

The deployment is using the Microsoft ClickOnce technology. At every application startup, it should automatically check if a new version is available, and update it automatically if that's the case.

For release notes and other assets associated with each release, check the releases tab of this project.
