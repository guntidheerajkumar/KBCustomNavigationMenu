using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace KBCustomNavigationMenu
{
	delegate void NSDispatchHandlerT();
	// @interface KBDropdownView : NSObject
	[BaseType(typeof(NSObject))]
	interface KBDropdownView
	{
		// @property (assign, nonatomic) CGFloat closedScale;
		[Export("closedScale")]
		nfloat ClosedScale { get; set; }

		// @property (assign, nonatomic) BOOL shouldBlurContainerView;
		[Export("shouldBlurContainerView")]
		bool ShouldBlurContainerView { get; set; }

		// @property (assign, nonatomic) CGFloat blurRadius;
		[Export("blurRadius")]
		nfloat BlurRadius { get; set; }

		// @property (assign, nonatomic) CGFloat blackMaskAlpha;
		[Export("blackMaskAlpha")]
		nfloat BlackMaskAlpha { get; set; }

		// @property (assign, nonatomic) CGFloat animationDuration;
		[Export("animationDuration")]
		nfloat AnimationDuration { get; set; }

		// @property (assign, nonatomic) CGFloat animationBounceHeight;
		[Export("animationBounceHeight")]
		nfloat AnimationBounceHeight { get; set; }

		// @property (assign, nonatomic) KBDropdownViewDirection direction;
		[Export("direction", ArgumentSemantic.Assign)]
		KBDropdownViewDirection Direction { get; set; }

		// @property (nonatomic, strong) UIColor * contentBackgroundColor;
		[Export("contentBackgroundColor", ArgumentSemantic.Strong)]
		UIColor ContentBackgroundColor { get; set; }

		// @property (readonly, assign, nonatomic) KBDropdownViewState currentState;
		[Export("currentState", ArgumentSemantic.Assign)]
		KBDropdownViewState CurrentState { get; }

		// @property (readonly, assign, nonatomic) BOOL isOpen;
		[Export("isOpen")]
		bool IsOpen { get; }

		[Wrap("WeakDelegate")]
		KBDropdownViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<KBDropdownViewDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) dispatch_block_t didShowHandler;
		[Export("didShowHandler", ArgumentSemantic.Copy)]
		NSDispatchHandlerT DidShowHandler { get; set; }

		// @property (copy, nonatomic) dispatch_block_t didHideHandler;
		[Export("didHideHandler", ArgumentSemantic.Copy)]
		NSDispatchHandlerT DidHideHandler { get; set; }

		// +(instancetype)dropdownView;
		[Static]
		[Export("dropdownView")]
		KBDropdownView DropdownView();

		// -(void)showInView:(UIView *)containerView withContentView:(UIView *)contentView atOrigin:(CGPoint)origin;
		[Export("showInView:withContentView:atOrigin:")]
		void ShowInView(UIView containerView, UIView contentView, CGPoint origin);

		// -(void)showFromNavigationController:(UINavigationController *)navigationController withContentView:(UIView *)contentView;
		[Export("showFromNavigationController:withContentView:")]
		void ShowFromNavigationController(UINavigationController navigationController, UIView contentView);

		// -(void)hide;
		[Export("hide")]
		void Hide();

		// -(void)forceHide;
		[Export("forceHide")]
		void ForceHide();
	}

	// @protocol KBDropdownViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface KBDropdownViewDelegate
	{
		// @optional -(void)dropdownViewWillShow:(KBDropdownView *)dropdownView;
		[Export("dropdownViewWillShow:")]
		void DropdownViewWillShow(KBDropdownView dropdownView);

		// @optional -(void)dropdownViewDidShow:(KBDropdownView *)dropdownView;
		[Export("dropdownViewDidShow:")]
		void DropdownViewDidShow(KBDropdownView dropdownView);

		// @optional -(void)dropdownViewWillHide:(KBDropdownView *)dropdownView;
		[Export("dropdownViewWillHide:")]
		void DropdownViewWillHide(KBDropdownView dropdownView);

		// @optional -(void)dropdownViewDidHide:(KBDropdownView *)dropdownView;
		[Export("dropdownViewDidHide:")]
		void DropdownViewDidHide(KBDropdownView dropdownView);
	}
}
