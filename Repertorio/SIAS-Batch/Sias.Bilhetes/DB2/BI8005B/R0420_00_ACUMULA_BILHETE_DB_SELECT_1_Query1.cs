using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT
            FROM SEGUROS.CLIENTES A,
            SEGUROS.BILHETE B,
            SEGUROS.ENDOSSOS C
            WHERE A.CGCCPF = :V0CLIE-CGCCPF
            AND B.COD_CLIENTE = A.COD_CLIENTE
            AND B.SITUACAO = '9'
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.COD_PRODUTO IN ( :WHOST-PROD-MENSAL ,
            :WHOST-PROD-PUANTE )
            AND C.NUM_ENDOSSO = 0
            AND C.DATA_TERVIGENCIA >= :V1SIST-DTMOVABE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.CLIENTES A
							,
											SEGUROS.BILHETE B
							,
											SEGUROS.ENDOSSOS C
											WHERE A.CGCCPF = '{this.V0CLIE_CGCCPF}'
											AND B.COD_CLIENTE = A.COD_CLIENTE
											AND B.SITUACAO = '9'
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.COD_PRODUTO IN ( '{this.WHOST_PROD_MENSAL}' 
							,
											'{this.WHOST_PROD_PUANTE}' )
											AND C.NUM_ENDOSSO = 0
											AND C.DATA_TERVIGENCIA >= '{this.V1SIST_DTMOVABE}'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string WHOST_PROD_MENSAL { get; set; }
        public string WHOST_PROD_PUANTE { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0CLIE_CGCCPF { get; set; }

        public static R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 Execute(R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 r0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_ACUMULA_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}