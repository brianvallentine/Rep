using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0912S
{
    public class R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            T1.ORGAO_EMISSOR,
            T1.RAMO_EMISSOR,
            T2.COD_FONTE,
            T2.TIPO_ENDOSSO ,
            T1.COD_PRODUTO
            INTO :APOLICES-ORGAO-EMISSOR,
            :APOLICES-RAMO-EMISSOR,
            :ENDOSSOS-COD-FONTE,
            :ENDOSSOS-TIPO-ENDOSSO,
            :APOLICES-COD-PRODUTO:VIND-CODPRODU
            FROM SEGUROS.APOLICES T1,
            SEGUROS.ENDOSSOS T2
            WHERE T2.NUM_APOLICE = :WHOST-NUM-APOL
            AND T2.NUM_ENDOSSO = :WHOST-NRENDOS
            AND T1.NUM_APOLICE = T2.NUM_APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											T1.ORGAO_EMISSOR
							,
											T1.RAMO_EMISSOR
							,
											T2.COD_FONTE
							,
											T2.TIPO_ENDOSSO 
							,
											T1.COD_PRODUTO
											FROM SEGUROS.APOLICES T1
							,
											SEGUROS.ENDOSSOS T2
											WHERE T2.NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND T2.NUM_ENDOSSO = '{this.WHOST_NRENDOS}'
											AND T1.NUM_APOLICE = T2.NUM_APOLICE";

            return query;
        }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_TIPO_ENDOSSO { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }

        public static R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1 r1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_ENDOSSO = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.APOLICES_COD_PRODUTO) ? "-1" : "0";
            return dta;
        }

    }
}