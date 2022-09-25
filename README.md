# Kogane Texture Preprocessor

テクスチャのインポート設定を自動化するエディタ拡張

## 使い方

![2020-05-08_200602](https://user-images.githubusercontent.com/6134875/81400776-d686b480-9168-11ea-8aaf-c4312b08f2da.png)

Project ビューの「+ > UniTexture`Preprocessor」から設定を管理するアセットを作成できます

![2020-05-08_200632](https://user-images.githubusercontent.com/6134875/81400779-d7b7e180-9168-11ea-849f-f4ac5d86717f.png)

「TextureImporterSettings」は

![2020-05-08_200728](https://user-images.githubusercontent.com/6134875/81400781-d7b7e180-9168-11ea-8bc2-77c61370d02a.png)

テクスチャの Import Settings を上書きする設定を管理するアセットです  
上書きしたい項目をチェックして、上書きしたいパラメータを設定できます

![2020-05-08_200808](https://user-images.githubusercontent.com/6134875/81400783-d8507800-9168-11ea-9f04-c4ef67ec39b0.png)

「TextureImporterPlatformSettings」は

![2020-05-08_200825](https://user-images.githubusercontent.com/6134875/81400785-d8507800-9168-11ea-802e-5a2fd109fa8e.png)

テクスチャのプラットフォームごとの Import Settings を上書きする設定を管理するアセットです  
「TextureImporterSettings」の「XXXX Settings」の項目に参照を設定できます

「TextureImporterSettings」と「TextureImporterPlatformSettings」は作成するだけでは何も起きません

![2020-05-08_200920](https://user-images.githubusercontent.com/6134875/81400792-dbe3ff00-9168-11ea-8921-67698de62278.png)

「TexturePreprocessorSettings」は、どこのパスに存在するアセットに  
どの「TextureImporterSettings」を適用するか設定できるアセットです  
「Path」は先頭一致（StartsWith）で判定されます

「TexturePreprocessorSettings」を作成しておくことで  
テクスチャがインポートされた時に設定が上書きされるようになります

「TextureImporterSettings」と「TextureImporterPlatformSettings」は複数作成可能です  
「TexturePreprocessorSettings」は1つのみ作成可能です

## 使用例

![2020-05-08_201305](https://user-images.githubusercontent.com/6134875/81400794-dd152c00-9168-11ea-9299-ca6f62781ff8.png)

「TextureImporterPlatformSettings」を作成して上記のように項目を設定します

![2020-05-08_201316](https://user-images.githubusercontent.com/6134875/81400795-dd152c00-9168-11ea-9c9c-3d82052f0a6c.png)

「TextureImporterSettings」を作成して上記のように項目を設定します

![2020-05-08_201356](https://user-images.githubusercontent.com/6134875/81400796-ddadc280-9168-11ea-9e17-ad8b53ac750b.png)

「TexturePreprocessorSettings」を作成して上記のように項目を設定します

![2020-05-08_201451](https://user-images.githubusercontent.com/6134875/81400797-de465900-9168-11ea-85de-f91abf34f129.png)

そして、「TexturePreprocessorSettings」の「Path」に指定したフォルダに存在する  
テクスチャをインポートし直すと

![2020-05-08_201509](https://user-images.githubusercontent.com/6134875/81400798-de465900-9168-11ea-8feb-8c806cdccfbd.png)

テクスチャの Import Settings が

![2020-05-08_201522](https://user-images.githubusercontent.com/6134875/81400799-dedeef80-9168-11ea-9f6c-10b0b74587e4.png)

設定した内容で上書きされることが確認できます

## SpriteAtlas

![2020-05-08_200602](https://user-images.githubusercontent.com/6134875/81400776-d686b480-9168-11ea-8aaf-c4312b08f2da.png)

「SpriteAtlasPreprocessorSettings」と「SpriteAtlasImporterSettings」を作成すると  
SpriteAtlas のインポート設定を自動化することができます  