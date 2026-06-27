# AudioManager v1.0.0

音声の再生に便利なやつ

---

## BGM

### 再生

```csharp
AudioManager.Instance.PlayBGM("BattleTheme");

//音量を指定する場合（デフォルトは1）
AudioManager.Instance.PlayBGM("BattleTheme", 0.8f);
```

> フェード中は再生できません。

### 一時停止 / 停止

```csharp
//一時停止（Resume不可。再開はPlayBGMから）
AudioManager.Instance.PauseBGM();

//停止（フェード中は不可）
AudioManager.Instance.StopBGM();

//強制停止（フェード中でも停止可）
AudioManager.Instance.ForcedStopBGM();
```

---

## フェードイン / フェードアウト

### フェードイン

```csharp
//現在再生中のBGMをフェードインさせる
AudioManager.Instance.FadeInBGM(fadeInAmount: 0.5f, targetVolume: 1f);

//BGMを指定してフェードインさせる
AudioManager.Instance.FadeInBGM(fadeInAmount: 0.5f, targetVolume: 1f, bgmName: "TitleTheme");

//フェードイン完了後にコールバックを実行する
AudioManager.Instance.FadeInBGM(fadeInAmount: 0.5f, targetVolume: 1f, bgmName: "TitleTheme", callback: () => Debug.Log("フェードイン完了"));
```

### フェードアウト

```csharp
//フェードアウトしてBGMを停止する（デフォルト動作）
AudioManager.Instance.FadeOutBGM(fadeOutAmount: 0.5f);

//途中の音量で止める（停止はしない）
AudioManager.Instance.FadeOutBGM(fadeOutAmount: 0.5f, targetVolume: 0.3f, isStop: false);

//フェードアウト完了後にコールバックを実行する
AudioManager.Instance.FadeOutBGM(fadeOutAmount: 0.5f, targetVolume: 1f, callback: () => AudioManager.Instance.PlayBGM("TitleTheme"));
```

---

## SE / UI音

```csharp
//SE再生（デフォルト音量は1）
AudioManager.Instance.PlaySE("Explosion");
AudioManager.Instance.PlaySE("Explosion", 0.5f);

//UI音再生
AudioManager.Instance.PlayUI("ButtonClick");
AudioManager.Instance.PlayUI("ButtonClick", 0.8f);
```

> SE・UI音は `PlayOneShot` で再生されるため、重ねて再生できます。

---

## 音量設定

`Volume` プロパティ経由で `VolumeSetter` を操作します。

```csharp
AudioManager.Instance.Volume.BGM_Volume = 0.8f;
AudioManager.Instance.Volume.SE_Volume = 0.5f;
```