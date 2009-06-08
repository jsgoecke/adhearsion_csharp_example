def launch_call_rpc(vars)
  ahn_log.ami vars   
  
  channel= vars["src"]
  exten= vars["dest"]
  options = { "Channel" => channel,
              "Context" =>  "callback",
              "Exten" =>    exten,
              "Priority" => “1”,
              "Callerid" => “33333” }
  result = Adhearsion::VoIP::Asterisk.manager_interface.originate options
  
  ahn_log.ami "status: call Queued" 
  ahn_log.ami result   
end