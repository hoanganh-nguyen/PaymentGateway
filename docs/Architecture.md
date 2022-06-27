# Payment Gateway Architecture 

## Assumption
The solution design should respond to these requirements:
- Operational excellence
- High security
- High performance
	- Traffic: 10K request/minutes
	- Response Time: < 1s
- Reliability
- Cost optimization 

The solution compose 4 blocks:
- Traffic routing
- Compute 
- Storage (to store the payment details for the retrieving API)
- Monitoring

And the solution should be deployed in multi-region in active-active mode to:
- reduce the response time for world wide customers
- fail-over (in the case one or more regions down. Example in 2021)

## Option for Storage
The retrieving payment details APIs are designed for the reporting purpose. That's why the response time is not the top priortity. The solution shoule consider:
1. Security
2. Multi-region 
3. Cost
4. Performance

Here are the comparaison for these options
**Option 1: S3**

Advatages:
- Low cost
- Easy to use for multi-region deployment with multi-region replication & global endpoint
- Encryption at rest with KMS
- Basic security with ACL

Inconvenients:
- Average performance

**Option 2: RDS**
Advantages:
- Better performance than S3
- Cost affordable
- Encryption at rest with KMS
- Access management with roles

Incovenients:
- Most of RDS DB has only one way replication. In multi-region deployment, we should have an additional service to foward data to the master instance

**Option 3: Elasticache**
Avantages:
- Top performance (ms)
- Scalability
- Encryption at rest with KMS
- Regional

Incovenients:
- High cost
- Should not use for long-term stored 

**Option 4: DynamoDB**
Advantages:
- Good performance (better than S3, RDS but not yet matched Elasticache)
- Support multi-region with Global Tables
- Basic encryption & access management

**Recommendation: Using #Option 4**

## Option for Compute
### Option 1: Application Load Balancer + ECS/EKS	

![enter image description here](https://github.com/hoanganh-nguyen/PaymentGateway/blob/main/assets/ECS.png)

### Option 2: API Gateway + Lambda functions

![enter image description here](https://github.com/hoanganh-nguyen/PaymentGateway/blob/main/assets/API%20Gateway.png)
