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
    public class R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 : QueryBasis<R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            INTO :APOLICES-NUM-APOLICE
            FROM SEGUROS.PROPOSTAS_VA B
            WHERE NUM_APOLICE = :WHOST-NUM-APOLICE
            AND COD_SUBGRUPO = :WHOST-COD-SUBGRUPO
            AND SIT_REGISTRO IN ( '3' , '6' )
            AND DTPROXVEN <> '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											FROM SEGUROS.PROPOSTAS_VA B
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.WHOST_COD_SUBGRUPO}'
											AND SIT_REGISTRO IN ( '3' 
							, '6' )
											AND DTPROXVEN <> '9999-12-31'
											WITH UR";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string WHOST_COD_SUBGRUPO { get; set; }
        public string WHOST_NUM_APOLICE { get; set; }

        public static R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 Execute(R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 r8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1)
        {
            var ths = r8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}