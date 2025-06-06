using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<R1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_EMAIL (
            COD_PESSOA,
            SEQ_EMAIL,
            EMAIL,
            SITUACAO_EMAIL,
            COD_USUARIO,
            TIMESTAMP)
            VALUES(:PROPOVA-COD-CLIENTE,
            1,
            :DCLPESSOA-EMAIL.EMAIL,
            'A' ,
            'BI0080B' ,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_EMAIL ( COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP) VALUES({FieldThreatment(this.PROPOVA_COD_CLIENTE)}, 1, {FieldThreatment(this.EMAIL)}, 'A' , 'BI0080B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string EMAIL { get; set; }

        public static void Execute(R1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1 r1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = r1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1380_00_TRATA_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}