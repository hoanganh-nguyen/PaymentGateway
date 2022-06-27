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

## Options
### Option 1: Application Load Balancer + ECS/EKS	
### Option 2: API Gateway + Lambda functions
