﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Tools;
using DxLibDLL;

namespace Charlotte.Common
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public static class DDGround
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static DDTaskList EL = new DDTaskList();
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int PrimaryPadId = -1; // -1 == 未設定
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static DDSubScreen MainScreen = null; // null == 不使用
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static I4Rect MonitorRect;

		// DDConsts.Screen_WH ... システム上の画面サイズ
		// RealScreen_WH ... 実際の画面サイズ
		// RealScreenDraw_LTWH ... ゲーム画面を描画する位置とサイズ, _W == -1 の場合は { 0, 0, RealScreen_W, RealScreen_H } に描画する。

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int RealScreen_W = DDConsts.Screen_W;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int RealScreen_H = DDConsts.Screen_H;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int RealScreenDraw_L;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int RealScreenDraw_T;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int RealScreenDraw_W = -1; // -1 == RealScreenDraw_LTWH 不使用
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int RealScreenDraw_H;

		// MusicVolume:
		// 変更を反映するには -> DDMusicUtils.UpdateVolume();
		// 実際の音量は DDSoundUtils.MixVolume(DDGround.MusicVolume, <DDMusic>.Volume) になる。

		// SEVolume:
		// 変更を反映するには -> DDSEUtils.UpdateVolume();
		// 実際の音量は DDSoundUtils.MixVolume(DDGround.SEVolume, <DDSE>.Volume) になる。

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static double MusicVolume = DDConsts.DefaultVolume;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static double SEVolume = DDConsts.DefaultVolume;

		// RO_MouseDispMode:
		// マウスカーソルを表示するか
		// 変更を反映するには -> DDUtils.SetMouseDispMode(DDGround.RO_MouseDispMode);

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static bool RO_MouseDispMode = false;

		// Camera:
		// ICamera:
		//
		// カメラ位置を変更する場合、フレームループ内で描画を行う前に Camera を更新し、その直後に以下のとおり ICamera を更新すること。
		// DDGround.ICamera.X = DoubleTools.ToInt(DDGround.Camera.X);
		// DDGround.ICamera.Y = DoubleTools.ToInt(DDGround.Camera.Y);
		//
		// カメラ位置に影響を受ける画像の描画には ICamera の座標を使うこと。
		// 例：DDDraw.DrawCenter(picture, drawX - ICamera.X, drawY - ICamera.Y);

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static D2Point Camera = new D2Point();
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static I2Point ICamera = new I2Point();

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static DDGeneralResource GeneralResource;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static void INIT()
		{
			DDInput.DIR_2.BtnId = 0;
			DDInput.DIR_4.BtnId = 1;
			DDInput.DIR_6.BtnId = 2;
			DDInput.DIR_8.BtnId = 3;
			DDInput.A.BtnId = 4;
			DDInput.B.BtnId = 7;
			DDInput.C.BtnId = 5;
			DDInput.D.BtnId = 8;
			DDInput.E.BtnId = 6;
			DDInput.F.BtnId = 9;
			DDInput.L.BtnId = 10;
			DDInput.R.BtnId = 11;
			DDInput.PAUSE.BtnId = 13;
			DDInput.START.BtnId = 12;

			DDInput.DIR_2.KeyId = DX.KEY_INPUT_DOWN;
			DDInput.DIR_4.KeyId = DX.KEY_INPUT_LEFT;
			DDInput.DIR_6.KeyId = DX.KEY_INPUT_RIGHT;
			DDInput.DIR_8.KeyId = DX.KEY_INPUT_UP;
			DDInput.A.KeyId = DX.KEY_INPUT_Z;
			DDInput.B.KeyId = DX.KEY_INPUT_X;
			DDInput.C.KeyId = DX.KEY_INPUT_C;
			DDInput.D.KeyId = DX.KEY_INPUT_V;
			DDInput.E.KeyId = DX.KEY_INPUT_A;
			DDInput.F.KeyId = DX.KEY_INPUT_S;
			DDInput.L.KeyId = DX.KEY_INPUT_D;
			DDInput.R.KeyId = DX.KEY_INPUT_F;
			DDInput.PAUSE.KeyId = DX.KEY_INPUT_SPACE;
			DDInput.START.KeyId = DX.KEY_INPUT_RETURN;

			// app > @ INIT

			DDGround.RO_MouseDispMode = true;

			// < app
		}
	}
}
