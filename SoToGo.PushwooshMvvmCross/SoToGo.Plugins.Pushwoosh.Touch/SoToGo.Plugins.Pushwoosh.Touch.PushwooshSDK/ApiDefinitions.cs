using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using StoreKit;
using UIKit;

namespace Pushwoosh
{
	// typedef void (^PushwooshGetTagsHandler)(NSDictionary *);
	public delegate void PushwooshGetTagsHandler (NSDictionary arg0);

	// typedef void (^PushwooshErrorHandler)(NSError *);
	public delegate void PushwooshErrorHandler (NSError arg0);

	// @protocol PushNotificationDelegate
	[Protocol, Model]
	public interface PushNotificationDelegate
	{
		// @optional -(void)onDidRegisterForRemoteNotificationsWithDeviceToken:(NSString *)token;
		[Export ("onDidRegisterForRemoteNotificationsWithDeviceToken:")]
		void OnDidRegisterForRemoteNotificationsWithDeviceToken (string token);

		// @optional -(void)onDidFailToRegisterForRemoteNotificationsWithError:(NSError *)error;
		[Export ("onDidFailToRegisterForRemoteNotificationsWithError:")]
		void OnDidFailToRegisterForRemoteNotificationsWithError (NSError error);

		// @optional -(void)onPushReceived:(PushNotificationManager *)pushManager withNotification:(NSDictionary *)pushNotification onStart:(BOOL)onStart;
		[Export ("onPushReceived:withNotification:onStart:")]
		void OnPushReceived (PushNotificationManager pushManager, NSDictionary pushNotification, bool onStart);

		// @optional -(void)onPushAccepted:(PushNotificationManager *)pushManager withNotification:(NSDictionary *)pushNotification;
		[Export ("onPushAccepted:withNotification:")]
		void OnPushAccepted (PushNotificationManager pushManager, NSDictionary pushNotification);

		// @optional -(void)onPushAccepted:(PushNotificationManager *)pushManager withNotification:(NSDictionary *)pushNotification onStart:(BOOL)onStart;
		[Export ("onPushAccepted:withNotification:onStart:")]
		void OnPushAccepted (PushNotificationManager pushManager, NSDictionary pushNotification, bool onStart);

		// @optional -(void)onRichPageButtonTapped:(NSString *)customData;
		[Export ("onRichPageButtonTapped:")]
		void OnRichPageButtonTapped (string customData);

		// @optional -(void)onRichPageBackTapped;
		[Export ("onRichPageBackTapped")]
		void OnRichPageBackTapped ();

		// @optional -(void)onTagsReceived:(NSDictionary *)tags;
		[Export ("onTagsReceived:")]
		void OnTagsReceived (NSDictionary tags);

		// @optional -(void)onTagsFailedToReceive:(NSError *)error;
		[Export ("onTagsFailedToReceive:")]
		void OnTagsFailedToReceive (NSError error);

		// @optional -(void)onInAppClosed:(NSString *)code;
		[Export ("onInAppClosed:")]
		void OnInAppClosed (string code);

		// @optional -(void)onInAppDisplayed:(NSString *)code;
		[Export ("onInAppDisplayed:")]
		void OnInAppDisplayed (string code);
	}

	// @interface PWTags : NSObject
	[BaseType (typeof(NSObject))]
	public interface PWTags
	{
		// +(NSDictionary *)incrementalTagWithInteger:(NSInteger)delta;
		[Static]
		[Export ("incrementalTagWithInteger:")]
		NSDictionary IncrementalTagWithInteger (nint delta);
	}

	// @interface PushNotificationManager : NSObject <SKPaymentTransactionObserver>
	[BaseType (typeof(NSObject))]
	public interface PushNotificationManager : ISKPaymentTransactionObserver
	{
		// @property (copy, nonatomic) NSString * appCode;
		[Export ("appCode")]
		string AppCode { get; set; }

		// @property (copy, nonatomic) NSString * appName;
		[Export ("appName")]
		string AppName { get; set; }

		[Wrap ("WeakDelegate")]
		PushNotificationDelegate Delegate { get; set; }

		// @property (assign, nonatomic) NSObject<PushNotificationDelegate> * delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL showPushnotificationAlert;
		[Export ("showPushnotificationAlert")]
		bool ShowPushnotificationAlert { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary * launchNotification;
		[Export ("launchNotification", ArgumentSemantic.Copy)]
		NSDictionary LaunchNotification { get; }

		// +(void)initializeWithAppCode:(NSString *)appCode appName:(NSString *)appName;
		[Static]
		[Export ("initializeWithAppCode:appName:")]
		void InitializeWithAppCode (string appCode, string appName);

		// +(PushNotificationManager *)pushManager;
		[Static]
		[Export ("pushManager")]
		PushNotificationManager PushManager { get; }

		// -(void)registerForPushNotifications;
		[Export ("registerForPushNotifications")]
		void RegisterForPushNotifications ();

		// -(void)unregisterForPushNotifications;
		[Export ("unregisterForPushNotifications")]
		void UnregisterForPushNotifications ();

		// -(id)initWithApplicationCode:(NSString *)appCode appName:(NSString *)appName;
		[Export ("initWithApplicationCode:appName:")]
		IntPtr Constructor (string appCode, string appName);

		// -(id)initWithApplicationCode:(NSString *)appCode navController:(UIViewController *)navController appName:(NSString *)appName __attribute__((deprecated("")));
		[Export ("initWithApplicationCode:navController:appName:")]
		IntPtr Constructor (string appCode, UIViewController navController, string appName);

		// -(void)startLocationTracking;
		[Export ("startLocationTracking")]
		void StartLocationTracking ();

		// -(void)stopLocationTracking;
		[Export ("stopLocationTracking")]
		void StopLocationTracking ();

		// -(void)startBeaconTracking;
		[Export ("startBeaconTracking")]
		void StartBeaconTracking ();

		// -(void)stopBeaconTracking;
		[Export ("stopBeaconTracking")]
		void StopBeaconTracking ();

		// -(void)setTags:(NSDictionary *)tags;
		[Export ("setTags:")]
		void SetTags (NSDictionary tags);

		// -(void)setTags:(NSDictionary *)tags withCompletion:(void (^)(NSError *))completion;
		[Export ("setTags:withCompletion:")]
		void SetTags (NSDictionary tags, Action<NSError> completion);

		// -(void)loadTags;
		[Export ("loadTags")]
		void LoadTags ();

		// -(void)loadTags:(PushwooshGetTagsHandler)successHandler error:(PushwooshErrorHandler)errorHandler;
		[Export ("loadTags:error:")]
		void LoadTags (PushwooshGetTagsHandler successHandler, PushwooshErrorHandler errorHandler);

		// -(void)sendAppOpen;
		[Export ("sendAppOpen")]
		void SendAppOpen ();

		// -(void)sendBadges:(NSInteger)badge;
		[Export ("sendBadges:")]
		void SendBadges (nint badge);

		// -(void)sendLocation:(CLLocation *)location;
		[Export ("sendLocation:")]
		void SendLocation (CLLocation location);

		// -(void)sendSKPaymentTransactions:(NSArray *)transactions;
		[Export ("sendSKPaymentTransactions:")]
		void SendSKPaymentTransactions (NSObject[] transactions);

		// -(void)sendPurchase:(NSString *)productIdentifier withPrice:(NSDecimalNumber *)price currencyCode:(NSString *)currencyCode andDate:(NSDate *)date;
		[Export ("sendPurchase:withPrice:currencyCode:andDate:")]
		void SendPurchase (string productIdentifier, NSDecimalNumber price, string currencyCode, NSDate date);

		// -(NSString *)getPushToken;
		[Export ("getPushToken")]
		string PushToken { get; }

		// -(NSString *)getHWID;
		[Export ("getHWID")]
		string HWID { get; }

		// -(void)handlePushRegistration:(NSData *)devToken;
		[Export ("handlePushRegistration:")]
		void HandlePushRegistration (NSData devToken);

		// -(void)handlePushRegistrationString:(NSString *)deviceID;
		[Export ("handlePushRegistrationString:")]
		void HandlePushRegistrationString (string deviceID);

		// -(void)handlePushRegistrationFailure:(NSError *)error;
		[Export ("handlePushRegistrationFailure:")]
		void HandlePushRegistrationFailure (NSError error);

		// -(BOOL)handlePushReceived:(NSDictionary *)userInfo;
		[Export ("handlePushReceived:")]
		bool HandlePushReceived (NSDictionary userInfo);

		// -(NSDictionary *)getApnPayload:(NSDictionary *)pushNotification;
		[Export ("getApnPayload:")]
		NSDictionary GetApnPayload (NSDictionary pushNotification);

		// -(NSString *)getCustomPushData:(NSDictionary *)pushNotification;
		[Export ("getCustomPushData:")]
		string GetCustomPushData (NSDictionary pushNotification);

		// -(NSDictionary *)getCustomPushDataAsNSDict:(NSDictionary *)pushNotification;
		[Export ("getCustomPushDataAsNSDict:")]
		NSDictionary GetCustomPushDataAsNSDict (NSDictionary pushNotification);

		// +(NSMutableDictionary *)getRemoteNotificationStatus;
		[Static]
		[Export ("getRemoteNotificationStatus")]
		NSMutableDictionary RemoteNotificationStatus { get; }

		// +(void)clearNotificationCenter;
		[Static]
		[Export ("clearNotificationCenter")]
		void ClearNotificationCenter ();

		// -(void)setUserId:(NSString *)userId;
		[Export ("setUserId:")]
		void SetUserId (string userId);

		// -(void)mergeUserId:(NSString *)oldUserId to:(NSString *)newUserId doMerge:(BOOL)doMerge completion:(void (^)(NSError *))completion;
		[Export ("mergeUserId:to:doMerge:completion:")]
		void MergeUserId (string oldUserId, string newUserId, bool doMerge, Action<NSError> completion);

		// -(void)postEvent:(NSString *)event withAttributes:(NSDictionary *)attributes completion:(void (^)(NSError *))completion;
		[Export ("postEvent:withAttributes:completion:")]
		void PostEvent (string @event, NSDictionary attributes, Action<NSError> completion);

		// -(void)postEvent:(NSString *)event withAttributes:(NSDictionary *)attributes;
		[Export ("postEvent:withAttributes:")]
		void PostEvent (string @event, NSDictionary attributes);
	}

}