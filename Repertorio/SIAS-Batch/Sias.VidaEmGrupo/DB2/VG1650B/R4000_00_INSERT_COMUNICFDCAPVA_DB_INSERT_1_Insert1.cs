using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.COMUNIC_FED_CAP_VA
            (NUM_CERTIFICADO,
            SITUACAO,
            DATA_MOVIMENTO,
            TIMESTAMP)
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :COMFEDCA-SITUACAO,
            :COBHISVI-DATA-VENCIMENTO,
            CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA (NUM_CERTIFICADO, SITUACAO, DATA_MOVIMENTO, TIMESTAMP) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.COMFEDCA_SITUACAO)}, {FieldThreatment(this.COBHISVI_DATA_VENCIMENTO)}, CURRENT TIMESTAMP )";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string COMFEDCA_SITUACAO { get; set; }
        public string COBHISVI_DATA_VENCIMENTO { get; set; }

        public static void Execute(R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1 r4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}