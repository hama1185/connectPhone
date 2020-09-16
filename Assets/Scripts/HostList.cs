﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class HostList {
    static public Host phone1 = new Host(
        "192.168.11.58",
        "192.168.11.3",
        8000,
        8001,
        8002,
        8005,
        8007,
        8008
    );
    static public Host phone2 = new Host(
        "192.168.11.59",
        "192.168.11.4",
        8001,
        8000,
        8002,
        8006,
        8007,
        8008
    );
    static public string ip_audience = "192.168.11.60";//古いスマホ
    static public string ip_umpire = "192.168.11.61";//古いスマホ

    static public ID clientID = new ID(
        "enemy",
        "raspberry",
        "audenece"
    );
    static public ServerName serverName = new ServerName(
        "status",
        "flag",
        "realsence",
        "umpire"
    );

    public class Host {
        public string ip {get; set;}
        public string ip_raspberrypi {get; set;}
        public int port_status {get; set;}
        public int port_flag {get; set;}
        public int port_realsense {get; set;}
        public int port_audienceserver {get; set;}
        public int port_raspberrypi {get; set;}
        public int port_umpireReceive {get; set;}

        public Host(string ip1, string ip2, int port1, int port2, int port3, int port4, int port5, int port6) {
            ip = ip1;
            ip_raspberrypi = ip2;
            port_status = port1;
            port_flag = port2;
            port_realsense = port3;
            port_audienceserver = port4;
            port_raspberrypi = port5;
            port_umpireReceive = port6;
        }
    }

    public class ID {
        public string enemy;
        public string raspberrypi;
        public string audience;

        public ID(string id1, string id2, string id3) {
            enemy = id1;
            raspberrypi = id2;
            audience = id3;
        }
    }

    public class ServerName {
        public string status;
        public string flag;
        public string realsense;
        public string umpire;

        public ServerName(string name1, string name2, string name3, string name4) {
            status = name1;
            flag = name2;
            realsense = name3;
            umpire = name4;
        }
    }
}