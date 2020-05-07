# Signalr Hubs 
## Realtime Communications Hubs

### StockHub
>this provides the stock and stock impression managment and notifications for tradding 

#### Methods
SendNewStocks - Send a list of pulled stocks to all connected clients List<StockRate> 
  
AddStockSentiment - When a user starts a trade a packet with teh trade inromaiton is stored by the service to determine tradder sentiment for a period. 

#### Callbacks
'stocks' - callback used to receive new stock data

'stock_error' - callback used to capture hub server errors and request validation errors



