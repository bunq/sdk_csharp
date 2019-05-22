# Change Log

## [1.10.2](https://github.com/bunq/sdk_csharp/tree/1.10.2) (2019-05-09)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/1.10.1...1.10.2)

**Merged pull requests:**

- Fix Windows issues. \(bunq/sdk\_csharp\#124\) [\#126](https://github.com/bunq/sdk_csharp/pull/126) ([kojoru](https://github.com/kojoru))

## [1.10.1](https://github.com/bunq/sdk_csharp/tree/1.10.1) (2019-05-08)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/1.10.0...1.10.1)

## [1.10.0](https://github.com/bunq/sdk_csharp/tree/1.10.0) (2019-05-08)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/1.1.0...1.10.0)

**Closed issues:**

- PSD2 Support [\#124](https://github.com/bunq/sdk_csharp/issues/124)

**Merged pull requests:**

- Implement psd2 [\#125](https://github.com/bunq/sdk_csharp/pull/125) ([kojoru](https://github.com/kojoru))
- Add missing semicolons in README.md [\#123](https://github.com/bunq/sdk_csharp/pull/123) ([WouterJanson](https://github.com/WouterJanson))
- fix broken link in readme [\#120](https://github.com/bunq/sdk_csharp/pull/120) ([Niggggggo](https://github.com/Niggggggo))

## [1.1.0](https://github.com/bunq/sdk_csharp/tree/1.1.0) (2018-10-10)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/1.0.0...1.1.0)

**Fixed bugs:**

- Provided client public key has an incorrect modulus length. Modulus length must be "2048", got "1024" [\#92](https://github.com/bunq/sdk_csharp/issues/92)

**Closed issues:**

- Unable to Authenticate with Bunq [\#114](https://github.com/bunq/sdk_csharp/issues/114)

**Merged pull requests:**

- Fix key generation on .NET Framework. \(bunq/sdk\_csharp\#92\) [\#116](https://github.com/bunq/sdk_csharp/pull/116) ([kojoru](https://github.com/kojoru))

## [1.0.0](https://github.com/bunq/sdk_csharp/tree/1.0.0) (2018-07-24)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.13.1...1.0.0)

**Implemented enhancements:**

- Monetary account joint cannot be retrieved. [\#50](https://github.com/bunq/sdk_csharp/issues/50)
- \[csharp\] Update examples in readme [\#91](https://github.com/bunq/sdk_csharp/issues/91)
- Add test CI  [\#90](https://github.com/bunq/sdk_csharp/issues/90)
- It is not possible to refresh userContext data [\#89](https://github.com/bunq/sdk_csharp/issues/89)
- Optimise test framework.  [\#87](https://github.com/bunq/sdk_csharp/issues/87)
- Add more example scripts [\#77](https://github.com/bunq/sdk_csharp/issues/77)
- Auto save the session after automatic session reset has been executed  [\#72](https://github.com/bunq/sdk_csharp/issues/72)
- Added support for netstandard15. \(bunq/sdk\_csharp\#26\) [\#88](https://github.com/bunq/sdk_csharp/pull/88) ([OGKevin](https://github.com/OGKevin))

**Fixed bugs:**

- NullReferenceException when calling CustomerStatementExport.List [\#96](https://github.com/bunq/sdk_csharp/issues/96)

**Closed issues:**

- Singleton ApiContext with multi-thread code [\#103](https://github.com/bunq/sdk_csharp/issues/103)
- Add oauth support.  [\#112](https://github.com/bunq/sdk_csharp/issues/112)
- Update Sandbox API key procedure [\#101](https://github.com/bunq/sdk_csharp/issues/101)
- Move to new sandbox.  [\#99](https://github.com/bunq/sdk_csharp/issues/99)
- BunqSdk.Tests mention Java instead of C\# [\#97](https://github.com/bunq/sdk_csharp/issues/97)
- .net standard 2.0 support [\#93](https://github.com/bunq/sdk_csharp/issues/93)

**Merged pull requests:**

- Added travis config.  \(bunq/sdk\_csharp\#90\) [\#110](https://github.com/bunq/sdk_csharp/pull/110) ([OGKevin](https://github.com/OGKevin))
- Oauth bunq/sdk\_csharp\#112 [\#113](https://github.com/bunq/sdk_csharp/pull/113) ([OGKevin](https://github.com/OGKevin))
- Auto reload context bunq/sdk\_csharp\#72 [\#111](https://github.com/bunq/sdk_csharp/pull/111) ([OGKevin](https://github.com/OGKevin))
-  Updated the examples on readme. \(bunq/sdk\_csharp\#91\) [\#109](https://github.com/bunq/sdk_csharp/pull/109) ([OGKevin](https://github.com/OGKevin))
- Use tinker as examples bunq/sdk\_csharp\#77 [\#108](https://github.com/bunq/sdk_csharp/pull/108) ([OGKevin](https://github.com/OGKevin))
- Optimise test framework bunq/sdk\_csharp\#87 [\#107](https://github.com/bunq/sdk_csharp/pull/107) ([OGKevin](https://github.com/OGKevin))
- Added net standard 2 support. \(bunq/sdk\_csharp\#93\) [\#105](https://github.com/bunq/sdk_csharp/pull/105) ([nduijvelshoff](https://github.com/nduijvelshoff))
- Update Sandbox API key procedure \(bunq/sdk\_csharp\#101\) [\#102](https://github.com/bunq/sdk_csharp/pull/102) ([sandervdo](https://github.com/sandervdo))
- Changed sandbox url to the new one. \(bunq/sdk\_csharp\#99\) [\#100](https://github.com/bunq/sdk_csharp/pull/100) ([OGKevin](https://github.com/OGKevin))

## [0.13.1](https://github.com/bunq/sdk_csharp/tree/0.13.1) (2018-05-30)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.13.0...0.13.1)

**Merged pull requests:**

- Change Java to Csharp in readme. \(bunq/sdk\_csharp\#97\) [\#98](https://github.com/bunq/sdk_csharp/pull/98) ([robinvanpoppel](https://github.com/robinvanpoppel))

## [0.13.0](https://github.com/bunq/sdk_csharp/tree/0.13.0) (2018-03-20)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.12.4...0.13.0)

**Implemented enhancements:**

- Add zappr integration for better quality control  [\#66](https://github.com/bunq/sdk_csharp/issues/66)
- Add more information to templates. [\#64](https://github.com/bunq/sdk_csharp/issues/64)
- Add response id to error messages from failed requests  [\#63](https://github.com/bunq/sdk_csharp/issues/63)
- Add installation instructions to README.md [\#61](https://github.com/bunq/sdk_csharp/issues/61)

**Fixed bugs:**

- Token request ideal is missing id attribute in response. [\#76](https://github.com/bunq/sdk_csharp/issues/76)
- Field ID is missing from MasterCardAction [\#52](https://github.com/bunq/sdk_csharp/issues/52)
- TokenQrRequestIdeal returns the wrong type [\#51](https://github.com/bunq/sdk_csharp/issues/51)

**Closed issues:**

- Bunq update 7  [\#83](https://github.com/bunq/sdk_csharp/issues/83)

**Merged pull requests:**

- Regenerate code for release [\#82](https://github.com/bunq/sdk_csharp/pull/82) ([OGKevin](https://github.com/OGKevin))
- Regenerated code with correct object types. \(bunq/sdk\_csharp\#51\) [\#79](https://github.com/bunq/sdk_csharp/pull/79) ([OGKevin](https://github.com/OGKevin))
- Added missing field id for TokenQrRequestIdeal. \(bunq/sdk\_csharp\#76\) [\#78](https://github.com/bunq/sdk_csharp/pull/78) ([OGKevin](https://github.com/OGKevin))
- Added missing id field from mastercard action. \(bunq/sdk\_csharp\#52\) [\#74](https://github.com/bunq/sdk_csharp/pull/74) ([OGKevin](https://github.com/OGKevin))
- \(bunq/sdk\_csharp\#63\) add response id to failed request [\#73](https://github.com/bunq/sdk_csharp/pull/73) ([OGKevin](https://github.com/OGKevin))
- Configure Zappr [\#67](https://github.com/bunq/sdk_csharp/pull/67) ([OGKevin](https://github.com/OGKevin))
- Improve issue and pr template. \(bunq/sdk\_csharp\#64\) [\#65](https://github.com/bunq/sdk_csharp/pull/65) ([OGKevin](https://github.com/OGKevin))
- Added installation instructions to README.md. \(bunq/sdk\_csharp\#61\) [\#62](https://github.com/bunq/sdk_csharp/pull/62) ([OGKevin](https://github.com/OGKevin))
- Bunq update 7  [\#84](https://github.com/bunq/sdk_csharp/pull/84) ([OGKevin](https://github.com/OGKevin))

## [0.12.4](https://github.com/bunq/sdk_csharp/tree/0.12.4) (2017-12-21)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.12.3...0.12.4)

**Implemented enhancements:**

- Introduce CreateFromJsonString method. [\#56](https://github.com/bunq/sdk_csharp/issues/56)
- Make sure received signatures headers are correctly cased [\#49](https://github.com/bunq/sdk_csharp/issues/49)
- Return base class from createFromJsonString [\#48](https://github.com/bunq/sdk_csharp/issues/48)
- CHANGELOG.md is empty [\#46](https://github.com/bunq/sdk_csharp/issues/46)
- Improve decoder to recognise child objects [\#43](https://github.com/bunq/sdk_csharp/issues/43)
- Generated CHANGELOG.md :clap:. \(bunq/sdk\_csharp\#46\) [\#47](https://github.com/bunq/sdk_csharp/pull/47) ([OGKevin](https://github.com/OGKevin))

**Closed issues:**

- Payment example doesn't work without a name for the pointer [\#54](https://github.com/bunq/sdk_csharp/issues/54)

**Merged pull requests:**

- Ensure that headers are correctly cased before signature verification… [\#59](https://github.com/bunq/sdk_csharp/pull/59) ([OGKevin](https://github.com/OGKevin))
- Improve decoder bunq/sdk csharp\#43 [\#57](https://github.com/bunq/sdk_csharp/pull/57) ([OGKevin](https://github.com/OGKevin))

## [0.12.3](https://github.com/bunq/sdk_csharp/tree/0.12.3) (2017-11-15)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.12.2...0.12.3)

**Implemented enhancements:**

- Callback models for holding callback data  [\#41](https://github.com/bunq/sdk_csharp/issues/41)

**Fixed bugs:**

- ScheduledPayment causes decode error due to Typo [\#45](https://github.com/bunq/sdk_csharp/issues/45)

**Merged pull requests:**

- Feature/callback models bunq/sdk csharp\#41 [\#44](https://github.com/bunq/sdk_csharp/pull/44) ([OGKevin](https://github.com/OGKevin))

## [0.12.2](https://github.com/bunq/sdk_csharp/tree/0.12.2) (2017-11-08)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.12.0...0.12.2)

**Implemented enhancements:**

- Missing CARD GENERATED CVC2 endpoint [\#35](https://github.com/bunq/sdk_csharp/issues/35)
- More flexibility for sessionContext handling [\#28](https://github.com/bunq/sdk_csharp/issues/28)
- Feature/is session active\#33 [\#34](https://github.com/bunq/sdk_csharp/pull/34) ([OGKevin](https://github.com/OGKevin))
- Added cvc\_endpoint. \#35 [\#36](https://github.com/bunq/sdk_csharp/pull/36) ([OGKevin](https://github.com/OGKevin))

**Fixed bugs:**

- DraftPayment object field causes converter error [\#37](https://github.com/bunq/sdk_csharp/issues/37)

**Closed issues:**

- Add missing fields for cvc endpoint [\#38](https://github.com/bunq/sdk_csharp/issues/38)
- More flexibility for sessionContext handling [\#33](https://github.com/bunq/sdk_csharp/issues/33)

**Merged pull requests:**

- Bump C\# language version [\#29](https://github.com/bunq/sdk_csharp/pull/29) ([mikhail-denisenko](https://github.com/mikhail-denisenko))
- Feature/fix draft payment object \#37 [\#40](https://github.com/bunq/sdk_csharp/pull/40) ([OGKevin](https://github.com/OGKevin))
- Feature/add missing cvc fields \#38 [\#39](https://github.com/bunq/sdk_csharp/pull/39) ([OGKevin](https://github.com/OGKevin))

## [0.12.0](https://github.com/bunq/sdk_csharp/tree/0.12.0) (2017-10-11)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.11.0...0.12.0)

**Implemented enhancements:**

- Better error handling  [\#22](https://github.com/bunq/sdk_csharp/issues/22)
- Add Pagination [\#17](https://github.com/bunq/sdk_csharp/issues/17)
- Feature/exception handler [\#23](https://github.com/bunq/sdk_csharp/pull/23) ([OGKevin](https://github.com/OGKevin))
- Marked all files in generated dir as generated code. [\#21](https://github.com/bunq/sdk_csharp/pull/21) ([OGKevin](https://github.com/OGKevin))

**Closed issues:**

- Improve Model Namespaces [\#24](https://github.com/bunq/sdk_csharp/issues/24)

**Merged pull requests:**

- cleanup after 24-improve-namespaces [\#27](https://github.com/bunq/sdk_csharp/pull/27) ([dnl-blkv](https://github.com/dnl-blkv))
- Improve namespaces; cleanup \[\#24\] [\#25](https://github.com/bunq/sdk_csharp/pull/25) ([dnl-blkv](https://github.com/dnl-blkv))

## [0.11.0](https://github.com/bunq/sdk_csharp/tree/0.11.0) (2017-09-06)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.10.0...0.11.0)

**Implemented enhancements:**

- Ignore generated code for reviews [\#19](https://github.com/bunq/sdk_csharp/issues/19)
- Add proxy support  [\#15](https://github.com/bunq/sdk_csharp/issues/15)
- Response is missing response headers and pagination [\#5](https://github.com/bunq/sdk_csharp/issues/5)
- Added git attributes. [\#20](https://github.com/bunq/sdk_csharp/pull/20) ([OGKevin](https://github.com/OGKevin))
- Add pagination; add missing fields and objects \[\#17\] [\#18](https://github.com/bunq/sdk_csharp/pull/18) ([dnl-blkv](https://github.com/dnl-blkv))

## [0.10.0](https://github.com/bunq/sdk_csharp/tree/0.10.0) (2017-08-23)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.9.2...0.10.0)

**Implemented enhancements:**

- Allow saving context to JSON and restoring from it [\#13](https://github.com/bunq/sdk_csharp/issues/13)
- Bunq SDK needs two minor refactors [\#11](https://github.com/bunq/sdk_csharp/issues/11)
- add proxy support, make httpClient instance variable \[\#15\] [\#16](https://github.com/bunq/sdk_csharp/pull/16) ([dnl-blkv](https://github.com/dnl-blkv))
- add methods to serialize and de-serialize ApiContext, fix Card \[\#13\] [\#14](https://github.com/bunq/sdk_csharp/pull/14) ([dnl-blkv](https://github.com/dnl-blkv))

**Fixed bugs:**

- ArgumentException in SessionServerConverter [\#7](https://github.com/bunq/sdk_csharp/issues/7)

**Merged pull requests:**

- cleanup C\# SDK \[\#11\] [\#12](https://github.com/bunq/sdk_csharp/pull/12) ([dnl-blkv](https://github.com/dnl-blkv))
- Merge hotfixed master back to develop [\#10](https://github.com/bunq/sdk_csharp/pull/10) ([dnl-blkv](https://github.com/dnl-blkv))

## [0.9.2](https://github.com/bunq/sdk_csharp/tree/0.9.2) (2017-08-18)
[Full Changelog](https://github.com/bunq/sdk_csharp/compare/0.9.1...0.9.2)

**Implemented enhancements:**

- \#5 Introduce BunqResponse [\#6](https://github.com/bunq/sdk_csharp/pull/6) ([dnl-blkv](https://github.com/dnl-blkv))

**Fixed bugs:**

- Fix SessionServerConverter, bump up to 0.9.2.0-beta \[\#7\] [\#8](https://github.com/bunq/sdk_csharp/pull/8) ([dnl-blkv](https://github.com/dnl-blkv))

## [0.9.1](https://github.com/bunq/sdk_csharp/tree/0.9.1) (2017-08-07)
**Implemented enhancements:**

- Complete project info [\#3](https://github.com/bunq/sdk_csharp/issues/3)
- Added readme for tests  [\#2](https://github.com/bunq/sdk_csharp/pull/2) ([OGKevin](https://github.com/OGKevin))
- Add first wave unit-tests [\#1](https://github.com/bunq/sdk_csharp/pull/1) ([OGKevin](https://github.com/OGKevin))

**Merged pull requests:**

- Fix project info [\#4](https://github.com/bunq/sdk_csharp/pull/4) ([dnl-blkv](https://github.com/dnl-blkv))



\* *This Change Log was automatically generated by [github_changelog_generator](https://github.com/skywinder/Github-Changelog-Generator)*