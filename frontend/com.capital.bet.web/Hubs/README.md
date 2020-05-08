# Signalr Hubs 
## Realtime Communications Hubs
[Home](https://github.com/jayoharedee/capitalbet)

### StockHub
>this provides the stock and stock impression managment and notifications for tradding 

**Connecting**

```typescrypt
import * as signalR from "@aspnet/signalr";

private _connection: signalR.HubConnection;


 this._connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5000/stocks', { accessTokenFactory: () => this.auth.AccessToken })
        .build();

      this._connection.start()
        .then(() => {
          console.log('Stock Hub Connected ...');
        })
        .catch(err => console.log('Error while starting Stock Hub =>', err));

```


#### Methods
**SendNewStocks** - Send a list of pulled stocks to all connected clients List<StockRate> 
  
**AddStockTrade** - When a user starts a trade a packet with the trade informaiton is stored by the service to determine tradder sentiment for a period and store the trade inforamtion. 

#### Callbacks
'stocks' - callback used to receive new stock data

```typescript
this._connection.on('stocks', (data: StockRate[]) => {
      // do something with stock data
    });
```

'stock_error' - callback used to capture hub server errors and request validation errors

```typescript
this._connection.on('stock_error', (err:HubError) => {
      // handle errors
    });
```

'sentiments' - callback used to update the currency trading sentiment data

```typescript
this._connection.on('sentiments', (data: CurrencySentiment[]) => {
      // do something with sentiment data
    });
```



