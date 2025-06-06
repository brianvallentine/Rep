using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1110B
{
    public class P2420_BUSCA_CPF_DB_SELECT_1_Query1 : QueryBasis<P2420_BUSCA_CPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(GEPESFIS.NUM_CPF, 0)
            INTO :GEPESFIS-NUM-CPF
            FROM SEGUROS.GE_PESSOA_FISICA GEPESFIS
            WHERE GEPESFIS.COD_PESSOA = :GEPESSOA-COD-PESSOA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(GEPESFIS.NUM_CPF
							, 0)
											FROM SEGUROS.GE_PESSOA_FISICA GEPESFIS
											WHERE GEPESFIS.COD_PESSOA = '{this.GEPESSOA_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string GEPESFIS_NUM_CPF { get; set; }
        public string GEPESSOA_COD_PESSOA { get; set; }

        public static P2420_BUSCA_CPF_DB_SELECT_1_Query1 Execute(P2420_BUSCA_CPF_DB_SELECT_1_Query1 p2420_BUSCA_CPF_DB_SELECT_1_Query1)
        {
            var ths = p2420_BUSCA_CPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2420_BUSCA_CPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2420_BUSCA_CPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEPESFIS_NUM_CPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}