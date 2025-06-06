using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMBIL
            ,CODCLIEN
            ,OPC_COBERTURA
            ,RAMO
            ,VALUE(COD_PRODUTO,0)
            INTO :V1BILH-NUMBIL
            ,:V1BILH-COD-CLIENTE
            ,:V1BILH-OPC-COBER
            ,:V1BILH-RAMO
            ,:V1BILH-COD-PRODUTO
            FROM SEGUROS.V0BILHETE A
            WHERE A.NUM_APOLICE = :V0MOVDE-NUM-APOLICE
            AND A.SITUACAO = :V1BILH-SITUACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMBIL
											,CODCLIEN
											,OPC_COBERTURA
											,RAMO
											,VALUE(COD_PRODUTO
							,0)
											FROM SEGUROS.V0BILHETE A
											WHERE A.NUM_APOLICE = '{this.V0MOVDE_NUM_APOLICE}'
											AND A.SITUACAO = '{this.V1BILH_SITUACAO}'";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }
        public string V1BILH_COD_CLIENTE { get; set; }
        public string V1BILH_OPC_COBER { get; set; }
        public string V1BILH_RAMO { get; set; }
        public string V1BILH_COD_PRODUTO { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }
        public string V1BILH_SITUACAO { get; set; }

        public static R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1 Execute(R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1 r0116_00_LE_V1BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0116_00_LE_V1BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V1BILH_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V1BILH_OPC_COBER = result[i++].Value?.ToString();
            dta.V1BILH_RAMO = result[i++].Value?.ToString();
            dta.V1BILH_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}