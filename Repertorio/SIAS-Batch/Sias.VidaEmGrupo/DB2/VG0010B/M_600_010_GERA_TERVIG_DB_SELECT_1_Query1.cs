using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_600_010_GERA_TERVIG_DB_SELECT_1_Query1 : QueryBasis<M_600_010_GERA_TERVIG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CCT,
            COD_PRODUTO,
            NOME_PRODUTO
            INTO :WK-COD-CCT:WNUM-CCT,
            :PRODUVG-COD-PRODUTO,
            :PRODUVG-NOME-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE
            NUM_APOLICE = :MNUM-APOLICE AND
            COD_SUBGRUPO = :MCOD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CCT
							,
											COD_PRODUTO
							,
											NOME_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE
											NUM_APOLICE = '{this.MNUM_APOLICE}' AND
											COD_SUBGRUPO = '{this.MCOD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string WK_COD_CCT { get; set; }
        public string WNUM_CCT { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string MCOD_SUBGRUPO { get; set; }
        public string MNUM_APOLICE { get; set; }

        public static M_600_010_GERA_TERVIG_DB_SELECT_1_Query1 Execute(M_600_010_GERA_TERVIG_DB_SELECT_1_Query1 m_600_010_GERA_TERVIG_DB_SELECT_1_Query1)
        {
            var ths = m_600_010_GERA_TERVIG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_600_010_GERA_TERVIG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_600_010_GERA_TERVIG_DB_SELECT_1_Query1();
            var i = 0;
            dta.WK_COD_CCT = result[i++].Value?.ToString();
            dta.WNUM_CCT = string.IsNullOrWhiteSpace(dta.WK_COD_CCT) ? "-1" : "0";
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}