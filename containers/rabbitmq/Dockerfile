FROM rabbitmq:management-alpine

COPY ./config/rabbitmq.conf /etc/rabbitmq/rabbitmq.conf
COPY ./config/advanced.config /etc/rabbitmq/advanced.config
COPY ./config/definitions.json /etc/rabbitmq/definitions.json

RUN chown rabbitmq:rabbitmq /etc/rabbitmq/rabbitmq.conf /etc/rabbitmq/advanced.config /etc/rabbitmq/definitions.json