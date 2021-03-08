# KyebordRegsChanger  
+ キーボードのレイアウトをWindowsの設定画面で切替を行うとUS配列、JIS配列の共存が出来ない  
+ 切替には再起動が必要になる為、任意のタイミングでキーボードの入替などが難しい  
+ レジストリの操作で共存が可能であるが、変更に必要な情報を調べたりするのが手間である  
  
といった内容からGUI上で簡易に設定を切替れたいという思いのもと作成  
※ 設定の反映にはWindowsの再起動が必要になります。  
※ レジストリを書き換えるので、危険なソフトとして判定される事があります。  
  
  
---
# 通常版とLite版の違い
+ KeybordRegsChanger  
レジストリへのアクセスあり。  
現在の設定値の再現、設定の反映が直接可能。  
  
+ KeybordRegsChangerLite  
レジストリへのアクセス無し。  
現在の設定値を読込めない為、初期表示時の値を信用してはダメです。  
設定の反映には、プログラムで出力したバッチファイルを管理者権限で実行して下さい。
  
  
---
# 実行の準備  
+ KeybordRegsChanger.zip をダウンロード／解凍  
  (又は KeybordRegsChangerLite.zip ）
  
# 実行
KeybordRegsChanger.exe (KeybordRegsChangerLite.exe) を実行
  
## 読み書きされるレジストリ  
1. HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\i8042prt\Parameters  
こちらが通常設定されている値で、Windows全体としてキーボードの種類を設定する際に使用。  
新しいキーボードをつなげた時もこちらの設定が優勢される。  
  
| Value | Description |
|:-----------|:------------:|
| LayerDriver JPN | 日本語入力をする際のdll |
| OverrideKeyboardIdentifier | キーボードの数を設定する項目 |
| OverrideKeyboardType | キーボードの規格を設定する項目 |
| OverrideKeyboardSubtype | キーボードの数を設定する項目 |
  
2. HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\{デバイスID}\Device Parameters  
  
| Value | Description |
|:-----------|:------------:|
| KeybordName | デバイスIDだけでは後で見た時に何のキーボードか分からなくなるので<br>名前を付けれるように独自に設定|
| LayerDriver JPN | 日本語入力をする際のdll |
| OverrideKeyboardIdentifier | キーボードの数を設定する項目 |
| OverrideKeyboardType | キーボードの規格を設定する項目 |
| OverrideKeyboardSubtype | キーボードの数を設定する項目 |
| KeyboardTypeOverride | キーボードの規格を設定する項目 |
| KeyboardSubtypeOverride | キーボードの数を設定する項目 |
  
※ MS-IMEのバージョンによって「OverrideKeyboardType」「KeyboardTypeOverride」どちらかの設定が有効になるようになっており、余分に設定する分には影響しないので両方設定しています。
  
# 設定の反映  
+ KeybordRegsChanger  
レジストリへの書き込み」ボタンをクリック
  
+ KeybordRegsChangerLite  
「バッチの書き出し」ボタンをクリックすると、レジストリの変更を行うファイルが保存されます。    
右クリック「管理者として実行」をクリックして下さい
  
# 設定の反映後  
PCの再起動  
  
---