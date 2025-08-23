# Design a Dynamic Notification System
### Problem:
The system must support multiple notification channels — Email, SMS, Push Notification, and In-App Alerts — and allow dynamic selection based on user preferences, urgency level, and system configuration.

### 1. Define Strategy
```csharp
//Define a strategy
public interface INotificationStrategy {
    void Notify( NotificationData data ){ }
}

// Defining the Notification data class
public class NotificationData {

    private String recipient;
    private String message;
    private String channelType; // e.g., "EMAIL", "SMS", "PUSH"
    public NotificationData(String recipient, String message, String channelType) {
        this.recipient = recipient;
        this.message = message;
        this.channelType = channelType;
    }

    public String getRecipient() { return recipient; }
    public String getMessage() { return message; }
    public String getChannelType() { return channelType; }
}
```

### 2. Define strategies for type of notification (i.e. Concrete Strategies)

```csharp
//EMAIL
public class EmailNotificationStrategy implements INotificationStrategy {
    public void send(NotificationData data) {
        System.out.println("Sending EMAIL to " + data.getRecipient() + ": " + data.getMessage());
    }
}

//SMS
public class SMSNotificationStrategy implements NotificationStrategy {
    @Override
    public void send(NotificationData data) {
        System.out.println("Sending SMS to " + data.getRecipient() + ": " + data.getMessage());
    }
}

//PUSH
public class PushNotificationStrategy implements NotificationStrategy {
    @Override
    public void send(NotificationData data) {
        System.out.println("Sending PUSH to " + data.getRecipient() + ": " + data.getMessage());
    }
}

```

### 4. Create Strategy factory

```csharp
public class NotificationStrategyFactory {

    public NotificationStrategy GetStrategy(string type){
        if("EMAIL" == type) return new EmailNotificationStrategy();
        else if ("PUSH" == type) return new PushNotificationStrategy();
        else if ("SMS" == type) return new SMSNotificationStrategy();
        else return new EmailNotificationStrategy(); // default is email type
    }
}
```

### 5. Build Notification Service
```csharp
public class NotificationService()
{
    private NotificationStrategyFactory notificationFactory;

    //ctor
    public NotificationService( NotificationStrategyFactory notificationFactory){
        this.notificationFactory = notificationFactory;
    }

    public void NotifyUser(NotificationData data){
        NotificationStrategy strategy = notificationFactory.getStrategy(data.getChannelType());
        strategy.Notify(data);

    }
}
```

### 6. Driver code
```csharp
public class NotificationApp {
    public static void Main(string [] args){
        NotificationStrategyFactory factory = new NotificationStrategyFactory();
        NotificationService serice = new NotificationService(factory);

        NotificationData email = new NotificationData("vil@g.com", "Order Shipped", "EMAIL" );
        NotificationData sms = new NotificationData("9999998880", "Your OTP is 454545", "SMS");

        service.NotifyUser(email);
        service.NotifyUser(sms);
    }
}
```
