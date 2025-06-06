using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1 : QueryBasis<R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDADE_FINAL
            INTO :FAIXAETA-IDADE-FINAL
            FROM SEGUROS.FAIXA_ETARIA
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND IDADE_INICIAL <= :FAIXAETA-IDADE-INICIAL
            AND IDADE_FINAL >= :FAIXAETA-IDADE-INICIAL
            AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IDADE_FINAL
											FROM SEGUROS.FAIXA_ETARIA
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND IDADE_INICIAL <= '{this.FAIXAETA_IDADE_INICIAL}'
											AND IDADE_FINAL >= '{this.FAIXAETA_IDADE_INICIAL}'
											AND DATA_TERVIGENCIA IN ( '1999-12-31' 
							, '9999-12-31' )
											WITH UR";

            return query;
        }
        public string FAIXAETA_IDADE_FINAL { get; set; }
        public string FAIXAETA_IDADE_INICIAL { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1 Execute(R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1 r2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1)
        {
            var ths = r2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1();
            var i = 0;
            dta.FAIXAETA_IDADE_FINAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}