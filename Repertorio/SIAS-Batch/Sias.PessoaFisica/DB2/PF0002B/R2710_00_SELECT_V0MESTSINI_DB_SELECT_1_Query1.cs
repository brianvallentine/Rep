using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 : QueryBasis<R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT M.COD_PRODUTO,
            M.NUM_APOL_SINISTRO,
            P.NUM_RESSARC ,
            P.NUM_PARCELA
            INTO :V0MSIN-CODPRODU ,
            :V0MSIN-NUM-APOL-SINISTRO ,
            :V0MSIN-ACORDO ,
            :V0MSIN-NRPARCEL
            FROM SEGUROS.SINISTRO_MESTRE M,
            SEGUROS.SI_RESSARC_PARCELA P
            WHERE P.NUM_NOSSO_TITULO = :SI111-NUM-NOSSO-TITULO
            AND P.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO
            AND P.COD_OPERACAO = 4000
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT M.COD_PRODUTO
							,
											M.NUM_APOL_SINISTRO
							,
											P.NUM_RESSARC 
							,
											P.NUM_PARCELA
											FROM SEGUROS.SINISTRO_MESTRE M
							,
											SEGUROS.SI_RESSARC_PARCELA P
											WHERE P.NUM_NOSSO_TITULO = '{this.SI111_NUM_NOSSO_TITULO}'
											AND P.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO
											AND P.COD_OPERACAO = 4000
											WITH UR";

            return query;
        }
        public string V0MSIN_CODPRODU { get; set; }
        public string V0MSIN_NUM_APOL_SINISTRO { get; set; }
        public string V0MSIN_ACORDO { get; set; }
        public string V0MSIN_NRPARCEL { get; set; }
        public string SI111_NUM_NOSSO_TITULO { get; set; }

        public static R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 Execute(R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 r2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = r2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2710_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MSIN_CODPRODU = result[i++].Value?.ToString();
            dta.V0MSIN_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0MSIN_ACORDO = result[i++].Value?.ToString();
            dta.V0MSIN_NRPARCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}