using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1 : QueryBasis<R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGC, NOME_FANTASIA
            INTO :PESSOJUR-CGC, :PESSOJUR-NOME-FANTASIA
            FROM SEGUROS.PESSOA_JURIDICA
            WHERE COD_PESSOA =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGC
							, NOME_FANTASIA
											FROM SEGUROS.PESSOA_JURIDICA
											WHERE COD_PESSOA =
											'{this.PROPOFID_COD_PESSOA}'";

            return query;
        }
        public string PESSOJUR_CGC { get; set; }
        public string PESSOJUR_NOME_FANTASIA { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1 Execute(R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1 r2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1)
        {
            var ths = r2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOJUR_CGC = result[i++].Value?.ToString();
            dta.PESSOJUR_NOME_FANTASIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}