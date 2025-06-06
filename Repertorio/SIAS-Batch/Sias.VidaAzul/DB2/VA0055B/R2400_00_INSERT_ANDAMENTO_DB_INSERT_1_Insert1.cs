using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0055B
{
    public class R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1 : QueryBasis<R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.VG_ANDAMENTO_PROP
            (NUM_CERTIFICADO,
            DTH_CADASTRAMENTO,
            DES_ANDAMENTO,
            COD_USUARIO)
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            CURRENT_TIMESTAMP,
            :VG078-DES-ANDAMENTO,
            'VA0055B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ANDAMENTO_PROP (NUM_CERTIFICADO, DTH_CADASTRAMENTO, DES_ANDAMENTO, COD_USUARIO) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, CURRENT_TIMESTAMP, {FieldThreatment(this.VG078_DES_ANDAMENTO)}, 'VA0055B' )";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string VG078_DES_ANDAMENTO { get; set; }

        public static void Execute(R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1 r2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}