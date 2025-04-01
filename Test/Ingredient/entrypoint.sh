#!/bin/bash
echo "Esperando 20 segundos para que el backend esté completamente listo..."
sleep 20
echo "Ejecutando JMeter..."
exec jmeter -n -t /jmeter/TestPost.jmx -l /jmeter/results.jtl -j /jmeter/jmeter.log -e -o /jmeter/reports
