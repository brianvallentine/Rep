using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 : QueryBasis<R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(B.NUM_APOLICE), 0)
            INTO :APOLICES-NUM-APOLICE
            FROM SEGUROS.CLIENTES A,
            SEGUROS.PROPOSTAS_VA B
            WHERE A.CGCCPF = :CLIENTES-CGCCPF
            AND B.COD_CLIENTE = A.COD_CLIENTE
            AND ((B.COD_PRODUTO IN (9311,9354,8203)
            AND B.NUM_APOLICE < 3000000000000)
            OR (B.COD_PRODUTO IN (:JVPRD9311,
            :JVPRD8203)
            AND B.NUM_APOLICE > 3000000000000))
            AND B.SIT_REGISTRO NOT IN ( '2' , '4' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(B.NUM_APOLICE)
							, 0)
											FROM SEGUROS.CLIENTES A
							,
											SEGUROS.PROPOSTAS_VA B
											WHERE A.CGCCPF = '{this.CLIENTES_CGCCPF}'
											AND B.COD_CLIENTE = A.COD_CLIENTE
											AND ((B.COD_PRODUTO IN (9311
							,9354
							,8203)
											AND B.NUM_APOLICE < 3000000000000)
											OR (B.COD_PRODUTO IN ('{this.JVPRD9311}'
							,
											'{this.JVPRD8203}')
											AND B.NUM_APOLICE > 3000000000000))
											AND B.SIT_REGISTRO NOT IN ( '2' 
							, '4' )
											WITH UR";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string JVPRD9311 { get; set; }
        public string JVPRD8203 { get; set; }

        public static R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 Execute(R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 r8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1)
        {
            var ths = r8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}