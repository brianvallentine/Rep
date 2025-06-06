using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP01B
{
    public class R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1 : QueryBasis<R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(FONTE),0)
            INTO :CEPFXFIL-FONTE
            FROM SEGUROS.CEPFAIXAFILIAL A
            WHERE A.DATA_INI_VIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO
            AND A.DATA_TER_VIGENCIA = '9999-12-31'
            AND A.CEP_INICIAL <= :FORNECED-CEP
            AND A.CEP_FINAL >= :FORNECED-CEP
            AND A.COD_EMPRESA = :PRODUTO-COD-EMPRESA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(FONTE)
							,0)
											FROM SEGUROS.CEPFAIXAFILIAL A
											WHERE A.DATA_INI_VIGENCIA <= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND A.DATA_TER_VIGENCIA = '9999-12-31'
											AND A.CEP_INICIAL <= '{this.FORNECED_CEP}'
											AND A.CEP_FINAL >= '{this.FORNECED_CEP}'
											AND A.COD_EMPRESA = '{this.PRODUTO_COD_EMPRESA}'";

            return query;
        }
        public string CEPFXFIL_FONTE { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string FORNECED_CEP { get; set; }

        public static R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1 Execute(R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1 r2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1)
        {
            var ths = r2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CEPFXFIL_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}