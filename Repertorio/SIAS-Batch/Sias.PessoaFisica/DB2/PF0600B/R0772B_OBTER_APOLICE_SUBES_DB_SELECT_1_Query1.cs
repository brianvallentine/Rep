using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1 : QueryBasis<R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_PRODUTO
            INTO :PRODUVG-NUM-APOLICE ,
            :PRODUVG-COD-SUBGRUPO,
            :PRODUVG-COD-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE COD_PRODUTO_AZUL = :PRODUVG-COD-PRODUTO-AZUL
            AND DATA_MINVIGENCIA <= :WHOST-DATA-PROPOSTA
            AND DATA_MAXVIGENCIA >= :WHOST-DATA-PROPOSTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											COD_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE COD_PRODUTO_AZUL = '{this.PRODUVG_COD_PRODUTO_AZUL}'
											AND DATA_MINVIGENCIA <= '{this.WHOST_DATA_PROPOSTA}'
											AND DATA_MAXVIGENCIA >= '{this.WHOST_DATA_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string PRODUVG_NUM_APOLICE { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_COD_PRODUTO_AZUL { get; set; }
        public string WHOST_DATA_PROPOSTA { get; set; }

        public static R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1 Execute(R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1 r0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1)
        {
            var ths = r0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PRODUVG_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}