using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1 : QueryBasis<R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_FORMA_PAGTO_AD,
            VALUE(COD_PARCEIRO, 0)
            INTO :AU085-IND-FORMA-PAGTO-AD,
            :AU085-COD-PARCEIRO
            FROM SEGUROS.AU_PROPOSTA_COMPL
            WHERE COD_FONTE = :V0ENDOS-FONTE
            AND NUM_PROPOSTA = :V0ENDOS-NRPROPOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_FORMA_PAGTO_AD
							,
											VALUE(COD_PARCEIRO
							, 0)
											FROM SEGUROS.AU_PROPOSTA_COMPL
											WHERE COD_FONTE = '{this.V0ENDOS_FONTE}'
											AND NUM_PROPOSTA = '{this.V0ENDOS_NRPROPOS}'";

            return query;
        }
        public string AU085_IND_FORMA_PAGTO_AD { get; set; }
        public string AU085_COD_PARCEIRO { get; set; }
        public string V0ENDOS_NRPROPOS { get; set; }
        public string V0ENDOS_FONTE { get; set; }

        public static R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1 Execute(R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1 r0101_00_RECUPERA_AU085_DB_SELECT_1_Query1)
        {
            var ths = r0101_00_RECUPERA_AU085_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0101_00_RECUPERA_AU085_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU085_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();
            dta.AU085_COD_PARCEIRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}