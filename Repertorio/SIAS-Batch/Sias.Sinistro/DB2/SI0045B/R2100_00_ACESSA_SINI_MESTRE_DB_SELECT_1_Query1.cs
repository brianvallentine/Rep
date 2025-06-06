using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1 : QueryBasis<R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_REGISTRO,
            COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_APOL_SINISTRO,
            NUM_APOLICE,
            NUM_ENDOSSO,
            OCORR_HISTORICO,
            DATA_COMUNICADO,
            DATA_OCORRENCIA,
            DATA_TECNICA,
            COD_CAUSA,
            NUM_IRB,
            NUM_AVISO_IRB,
            NUM_MOV_SINI_ATU,
            NUM_MOV_SINI_ANT,
            DATA_ULT_MOVIMENTO,
            SIT_REGISTRO,
            VALUE(RAMO,0),
            VALUE(COD_PRODUTO,0)
            INTO :SINISMES-TIPO-REGISTRO,
            :SINISMES-COD-FONTE,
            :SINISMES-NUM-PROTOCOLO-SINI,
            :SINISMES-DAC-PROTOCOLO-SINI,
            :SINISMES-NUM-APOL-SINISTRO,
            :SINISMES-NUM-APOLICE,
            :SINISMES-NUM-ENDOSSO,
            :SINISMES-OCORR-HISTORICO,
            :SINISMES-DATA-COMUNICADO,
            :SINISMES-DATA-OCORRENCIA,
            :SINISMES-DATA-TECNICA,
            :SINISMES-COD-CAUSA,
            :SINISMES-NUM-IRB,
            :SINISMES-NUM-AVISO-IRB,
            :SINISMES-NUM-MOV-SINI-ATU,
            :SINISMES-NUM-MOV-SINI-ANT,
            :SINISMES-DATA-ULT-MOVIMENTO,
            :SINISMES-SIT-REGISTRO,
            :SINISMES-RAMO,
            :SINISMES-COD-PRODUTO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_REGISTRO
							,
											COD_FONTE
							,
											NUM_PROTOCOLO_SINI
							,
											DAC_PROTOCOLO_SINI
							,
											NUM_APOL_SINISTRO
							,
											NUM_APOLICE
							,
											NUM_ENDOSSO
							,
											OCORR_HISTORICO
							,
											DATA_COMUNICADO
							,
											DATA_OCORRENCIA
							,
											DATA_TECNICA
							,
											COD_CAUSA
							,
											NUM_IRB
							,
											NUM_AVISO_IRB
							,
											NUM_MOV_SINI_ATU
							,
											NUM_MOV_SINI_ANT
							,
											DATA_ULT_MOVIMENTO
							,
											SIT_REGISTRO
							,
											VALUE(RAMO
							,0)
							,
											VALUE(COD_PRODUTO
							,0)
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINISMES_TIPO_REGISTRO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISMES_DAC_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_ENDOSSO { get; set; }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_TECNICA { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_NUM_IRB { get; set; }
        public string SINISMES_NUM_AVISO_IRB { get; set; }
        public string SINISMES_NUM_MOV_SINI_ATU { get; set; }
        public string SINISMES_NUM_MOV_SINI_ANT { get; set; }
        public string SINISMES_DATA_ULT_MOVIMENTO { get; set; }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }

        public static R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1 Execute(R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1 r2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISMES_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.SINISMES_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_TECNICA = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_NUM_IRB = result[i++].Value?.ToString();
            dta.SINISMES_NUM_AVISO_IRB = result[i++].Value?.ToString();
            dta.SINISMES_NUM_MOV_SINI_ATU = result[i++].Value?.ToString();
            dta.SINISMES_NUM_MOV_SINI_ANT = result[i++].Value?.ToString();
            dta.SINISMES_DATA_ULT_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISMES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}