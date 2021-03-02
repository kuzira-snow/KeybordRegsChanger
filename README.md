# KyebordRegsChanger  
+ キーボードのレイアウトをWindowsの設定画面で切替を行うとUS配列、JIS配列の共存が出来ない  
+ 切替には再起動が必要になる為、任意のタイミングでキーボードの入替などが難しい  
+ レジストリの操作で共存が可能であるが、変更に必要な情報を調べたりするのが手間である
といった内容からGUI上で簡易に設定を切替れたいという思いのもと作成  
  
# コードの状態  
まだ「とりあえずの動いた！」という段階です。  
不要な設定変更なども含まれていると思います。今後、最小限の設定だけにする予定。
また、レジストリを書き換えるので、危険なソフトとして判定されるとこともあります。  
いずれレジストリへの書き込みは行わないバージョンも作成しようかなと思ってます。    

# 準備  
+ KeybordRegsChanger.zip をダウンロード／解凍  
  
# 読み書きされるレジストリ  
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
| KeybordName | デバイスIDだけでは後で見た時に何のキーボードか分からなくなるので、名前を付けれるように独自に設定|
| LayerDriver JPN | 日本語入力をする際のdll |
| OverrideKeyboardIdentifier | キーボードの数を設定する項目 |
| OverrideKeyboardType | キーボードの規格を設定する項目 |
| OverrideKeyboardSubtype | キーボードの数を設定する項目 |
| KeyboardTypeOverride | キーボードの規格を設定する項目 |
| KeyboardSubtypeOverride | キーボードの数を設定する項目 |
  
MS-IMEのバージョンによって「OverrideKeyboardType」「KeyboardTypeOverride」どちらかの設定が有効になるっぽい。
  
  
