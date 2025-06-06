using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7239_SI2_SELECT_DB_SELECT_1_Query1 : QueryBasis<P7239_SI2_SELECT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            IDE_SISTEMA
            ,COD_OPERACAO
            ,COD_EVENTO_SAP
            ,COD_EVENTO_SAP_SFH
            ,VALUE(COD_EVENTO_SAP_JUD,
            COD_EVENTO_SAP)
            ,COD_EMPRESA_SAP
            ,COD_SISTEMA_SAP
            ,COD_ORIGEM_SAP
            INTO
            :SI239-IDE-SISTEMA
            ,:SI239-COD-OPERACAO
            ,:SI239-COD-EVENTO-SAP
            ,:SI239-COD-EVENTO-SAP-SFH
            ,:SI239-COD-EVENTO-SAP-JUD
            ,:SI239-COD-EMPRESA-SAP
            ,:SI239-COD-SISTEMA-SAP
            ,:SI239-COD-ORIGEM-SAP
            FROM SEGUROS.SI_OPERACAO_EVENTO
            WHERE IDE_SISTEMA = 'SI'
            AND COD_OPERACAO = :SI239-COD-OPERACAO
            AND (DTA_FIM_VIGENCIA = '9999-12-31'
            OR DTA_FIM_VIGENCIA IS NULL)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											IDE_SISTEMA
											,COD_OPERACAO
											,COD_EVENTO_SAP
											,COD_EVENTO_SAP_SFH
											,VALUE(COD_EVENTO_SAP_JUD
							,
											COD_EVENTO_SAP)
											,COD_EMPRESA_SAP
											,COD_SISTEMA_SAP
											,COD_ORIGEM_SAP
											FROM SEGUROS.SI_OPERACAO_EVENTO
											WHERE IDE_SISTEMA = 'SI'
											AND COD_OPERACAO = '{this.SI239_COD_OPERACAO}'
											AND (DTA_FIM_VIGENCIA = '9999-12-31'
											OR DTA_FIM_VIGENCIA IS NULL)
											WITH UR";

            return query;
        }
        public string SI239_IDE_SISTEMA { get; set; }
        public string SI239_COD_OPERACAO { get; set; }
        public string SI239_COD_EVENTO_SAP { get; set; }
        public string SI239_COD_EVENTO_SAP_SFH { get; set; }
        public string SI239_COD_EVENTO_SAP_JUD { get; set; }
        public string SI239_COD_EMPRESA_SAP { get; set; }
        public string SI239_COD_SISTEMA_SAP { get; set; }
        public string SI239_COD_ORIGEM_SAP { get; set; }

        public static P7239_SI2_SELECT_DB_SELECT_1_Query1 Execute(P7239_SI2_SELECT_DB_SELECT_1_Query1 p7239_SI2_SELECT_DB_SELECT_1_Query1)
        {
            var ths = p7239_SI2_SELECT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P7239_SI2_SELECT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P7239_SI2_SELECT_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI239_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.SI239_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SI239_COD_EVENTO_SAP = result[i++].Value?.ToString();
            dta.SI239_COD_EVENTO_SAP_SFH = result[i++].Value?.ToString();
            dta.SI239_COD_EVENTO_SAP_JUD = result[i++].Value?.ToString();
            dta.SI239_COD_EMPRESA_SAP = result[i++].Value?.ToString();
            dta.SI239_COD_SISTEMA_SAP = result[i++].Value?.ToString();
            dta.SI239_COD_ORIGEM_SAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}