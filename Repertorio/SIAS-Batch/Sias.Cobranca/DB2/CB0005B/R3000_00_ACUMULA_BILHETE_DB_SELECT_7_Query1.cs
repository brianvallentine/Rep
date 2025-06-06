using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1 : QueryBasis<R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT
            FROM SEGUROS.CLIENTES A
            , SEGUROS.BILHETE B
            , SEGUROS.ENDOSSOS C
            , SEGUROS.CONVERSAO_SICOB D
            WHERE A.CGCCPF = :V0CLIE-CGCCPF
            AND B.COD_CLIENTE = A.COD_CLIENTE
            AND B.SITUACAO = '9'
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.NUM_ENDOSSO = 0
            AND C.DATA_TERVIGENCIA > CURRENT DATE
            AND D.NUM_SICOB = B.NUM_BILHETE
            AND C.COD_PRODUTO IN (8530, 8531, 8532)
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.CLIENTES A
											, SEGUROS.BILHETE B
											, SEGUROS.ENDOSSOS C
											, SEGUROS.CONVERSAO_SICOB D
											WHERE A.CGCCPF = '{this.V0CLIE_CGCCPF}'
											AND B.COD_CLIENTE = A.COD_CLIENTE
											AND B.SITUACAO = '9'
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.NUM_ENDOSSO = 0
											AND C.DATA_TERVIGENCIA > CURRENT DATE
											AND D.NUM_SICOB = B.NUM_BILHETE
											AND C.COD_PRODUTO IN (8530
							, 8531
							, 8532)
											WITH UR";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string V0CLIE_CGCCPF { get; set; }

        public static R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1 Execute(R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1 r3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1)
        {
            var ths = r3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_ACUMULA_BILHETE_DB_SELECT_7_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}