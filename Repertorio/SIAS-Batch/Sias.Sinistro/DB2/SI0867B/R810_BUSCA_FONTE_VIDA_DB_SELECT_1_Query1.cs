using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0867B
{
    public class R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1 : QueryBasis<R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT F.NOME_FONTE
            INTO :FONTES-NOME-FONTE
            FROM SEGUROS.SEGURADOS_VGAP S,
            SEGUROS.FONTES F
            WHERE S.NUM_APOLICE = :W-GDA-APOLICE
            AND S.COD_SUBGRUPO = :W-GDA-SUBGRUPO
            AND S.NUM_CERTIFICADO = :W-GDA-NUM-CERTIFICADO
            AND F.COD_FONTE = :SEGURVGA-COD-FONTE
            AND S.TIPO_SEGURADO = :W-GDA-TIPO-SEGURADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT F.NOME_FONTE
											FROM SEGUROS.SEGURADOS_VGAP S
							,
											SEGUROS.FONTES F
											WHERE S.NUM_APOLICE = '{this.W_GDA_APOLICE}'
											AND S.COD_SUBGRUPO = '{this.W_GDA_SUBGRUPO}'
											AND S.NUM_CERTIFICADO = '{this.W_GDA_NUM_CERTIFICADO}'
											AND F.COD_FONTE = '{this.SEGURVGA_COD_FONTE}'
											AND S.TIPO_SEGURADO = '{this.W_GDA_TIPO_SEGURADO}'";

            return query;
        }
        public string FONTES_NOME_FONTE { get; set; }
        public string W_GDA_NUM_CERTIFICADO { get; set; }
        public string W_GDA_TIPO_SEGURADO { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }
        public string W_GDA_SUBGRUPO { get; set; }
        public string W_GDA_APOLICE { get; set; }

        public static R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1 Execute(R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1 r810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1)
        {
            var ths = r810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}