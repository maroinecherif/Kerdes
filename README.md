# Vickrey Auction API

This project models a sealed-bid second-price auction, specifically following the Vickrey Auction rules. It provides an API that accepts bids from multiple bidders and determines the winning bidder and bid price according to the specified conditions.

## Table of Contents
- [Objective](#objective)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Objective

The objective of this project is to implement an API that calculates the winner and winning bid price for a Vickrey Auction scenario based on provided bidder information and a reserve price.

## Features

- Accepts bids from multiple bidders.
- Determines the winning bidder and bid price according to Vickrey Auction rules.

## Getting Started

### Prerequisites

- .NET Core SDK
- Your favorite code editor (e.g., Visual Studio, Visual Studio Code)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/vickrey-auction-api.git
    cd vickrey-auction-api
    ```

2. Build and run the project:

    ```bash
    dotnet build
    dotnet run
    ```

## Usage

1. Make a POST request to the `/VickreyAuction/RunVickreyAuction` endpoint with the bidder information and reserve price in the request body.

    Example:

    ```bash
    curl -X POST -H "Content-Type: application/json" -d @example-request.json http://localhost:5000/VickreyAuction/RunVickreyAuction
    ```

    Example request body (save as `example-request.json`):

    ```json
    {
      "Bidders": [
        {"Name": "BidderA", "Bids": [110, 130]},
        {"Name": "BidderB", "Bids": []},
        {"Name": "BidderC", "Bids": [125]},
        {"Name": "BidderD", "Bids": [105, 115, 90]},
        {"Name": "BidderE", "Bids": [132, 135, 140]}
      ],
      "ReservePrice": 100
    }
    ```

2. The API will respond with the winning bidder and winning bid price.

## API Endpoints

- **POST /VickreyAuction/RunVickreyAuction**: Run the Vickrey Auction algorithm with provided bidder information and reserve price.

    Request Body:
    ```json
    {
      "Bidders": [
        {"Name": "BidderA", "Bids": [110, 130]},
        {"Name": "BidderB", "Bids": []},
        {"Name": "BidderC", "Bids": [125]},
        {"Name": "BidderD", "Bids": [105, 115, 90]},
        {"Name": "BidderE", "Bids": [132, 135, 140]}
      ],
      "ReservePrice": 100
    }
    ```

    Response:
    ```json
    {
      "WinningBidder": "BidderE",
      "WinningBidPrice": 130
    }
    ```

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## License

This project is licensed under the [MIT License](LICENSE).
