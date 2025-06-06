using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP6705B
{
    public class M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1 : QueryBasis<M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.COMISSOES_VP
            VALUES (:SQL-NUM-CERT ,
            :SQL-NRPARCEL ,
            :SQL-CODOPER-PLANOS ,
            :SQL-DTMOVABE ,
            :SQL-DTMOVABE ,
            :SQL-PRM-VG-CO ,
            :SQL-PRM-AP-CO ,
            '1' ,
            :SQL-PERC-COMIS ,
            :SQL-COD-FONTE ,
            :SQL-PROPOSTA ,
            '0' ,
            'VP6705B' ,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMISSOES_VP VALUES ({FieldThreatment(this.SQL_NUM_CERT)} , {FieldThreatment(this.SQL_NRPARCEL)} , {FieldThreatment(this.SQL_CODOPER_PLANOS)} , {FieldThreatment(this.SQL_DTMOVABE)} , {FieldThreatment(this.SQL_DTMOVABE)} , {FieldThreatment(this.SQL_PRM_VG_CO)} , {FieldThreatment(this.SQL_PRM_AP_CO)} , '1' , {FieldThreatment(this.SQL_PERC_COMIS)} , {FieldThreatment(this.SQL_COD_FONTE)} , {FieldThreatment(this.SQL_PROPOSTA)} , '0' , 'VP6705B' , CURRENT TIMESTAMP )";

            return query;
        }
        public string SQL_NUM_CERT { get; set; }
        public string SQL_NRPARCEL { get; set; }
        public string SQL_CODOPER_PLANOS { get; set; }
        public string SQL_DTMOVABE { get; set; }
        public string SQL_PRM_VG_CO { get; set; }
        public string SQL_PRM_AP_CO { get; set; }
        public string SQL_PERC_COMIS { get; set; }
        public string SQL_COD_FONTE { get; set; }
        public string SQL_PROPOSTA { get; set; }

        public static void Execute(M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1 m_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1)
        {
            var ths = m_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}