using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0341B
{
    public class R9000_FINALIZA_DB_INSERT_1_Insert1 : QueryBasis<R9000_FINALIZA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FITASASSE
            VALUES (:PARM-CODCONV,
            :PARM-NSA,
            :SIST-CURRDATE,
            :SIST-DTCREDITO,
            'VA0341B' ,
            '3' ,
            01,
            :PARM-VERSAO,
            :FITSAS-REG,
            0,
            :FITSAS-VALOR,
            :FITSAS-NSL,
            0,
            0,
            0,
            0,
            0,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FITASASSE VALUES ({FieldThreatment(this.PARM_CODCONV)}, {FieldThreatment(this.PARM_NSA)}, {FieldThreatment(this.SIST_CURRDATE)}, {FieldThreatment(this.SIST_DTCREDITO)}, 'VA0341B' , '3' , 01, {FieldThreatment(this.PARM_VERSAO)}, {FieldThreatment(this.FITSAS_REG)}, 0, {FieldThreatment(this.FITSAS_VALOR)}, {FieldThreatment(this.FITSAS_NSL)}, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string PARM_CODCONV { get; set; }
        public string PARM_NSA { get; set; }
        public string SIST_CURRDATE { get; set; }
        public string SIST_DTCREDITO { get; set; }
        public string PARM_VERSAO { get; set; }
        public string FITSAS_REG { get; set; }
        public string FITSAS_VALOR { get; set; }
        public string FITSAS_NSL { get; set; }

        public static void Execute(R9000_FINALIZA_DB_INSERT_1_Insert1 r9000_FINALIZA_DB_INSERT_1_Insert1)
        {
            var ths = r9000_FINALIZA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9000_FINALIZA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}