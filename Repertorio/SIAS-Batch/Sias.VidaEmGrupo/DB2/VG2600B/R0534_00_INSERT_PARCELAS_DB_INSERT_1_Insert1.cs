using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 : QueryBasis<R0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PARCELAS
            VALUES (:PARCELAS-NUM-APOLICE ,
            :PARCELAS-NUM-ENDOSSO ,
            :PARCELAS-NUM-PARCELA ,
            :PARCELAS-DAC-PARCELA ,
            :PARCELAS-COD-FONTE ,
            :PARCELAS-NUM-TITULO ,
            :PARCELAS-PRM-TARIFARIO-IX ,
            :PARCELAS-VAL-DESCONTO-IX ,
            :PARCELAS-PRM-LIQUIDO-IX ,
            :PARCELAS-ADICIONAL-FRAC-IX ,
            :PARCELAS-VAL-CUSTO-EMIS-IX ,
            :PARCELAS-VAL-IOCC-IX ,
            :PARCELAS-PRM-TOTAL-IX ,
            :PARCELAS-OCORR-HISTORICO ,
            :PARCELAS-QTD-DOCUMENTOS ,
            :PARCELAS-SIT-REGISTRO ,
            NULL ,
            CURRENT_TIMESTAMP ,
            NULL )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELAS VALUES ({FieldThreatment(this.PARCELAS_NUM_APOLICE)} , {FieldThreatment(this.PARCELAS_NUM_ENDOSSO)} , {FieldThreatment(this.PARCELAS_NUM_PARCELA)} , {FieldThreatment(this.PARCELAS_DAC_PARCELA)} , {FieldThreatment(this.PARCELAS_COD_FONTE)} , {FieldThreatment(this.PARCELAS_NUM_TITULO)} , {FieldThreatment(this.PARCELAS_PRM_TARIFARIO_IX)} , {FieldThreatment(this.PARCELAS_VAL_DESCONTO_IX)} , {FieldThreatment(this.PARCELAS_PRM_LIQUIDO_IX)} , {FieldThreatment(this.PARCELAS_ADICIONAL_FRAC_IX)} , {FieldThreatment(this.PARCELAS_VAL_CUSTO_EMIS_IX)} , {FieldThreatment(this.PARCELAS_VAL_IOCC_IX)} , {FieldThreatment(this.PARCELAS_PRM_TOTAL_IX)} , {FieldThreatment(this.PARCELAS_OCORR_HISTORICO)} , {FieldThreatment(this.PARCELAS_QTD_DOCUMENTOS)} , {FieldThreatment(this.PARCELAS_SIT_REGISTRO)} , NULL , CURRENT_TIMESTAMP , NULL )";

            return query;
        }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }
        public string PARCELAS_DAC_PARCELA { get; set; }
        public string PARCELAS_COD_FONTE { get; set; }
        public string PARCELAS_NUM_TITULO { get; set; }
        public string PARCELAS_PRM_TARIFARIO_IX { get; set; }
        public string PARCELAS_VAL_DESCONTO_IX { get; set; }
        public string PARCELAS_PRM_LIQUIDO_IX { get; set; }
        public string PARCELAS_ADICIONAL_FRAC_IX { get; set; }
        public string PARCELAS_VAL_CUSTO_EMIS_IX { get; set; }
        public string PARCELAS_VAL_IOCC_IX { get; set; }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string PARCELAS_OCORR_HISTORICO { get; set; }
        public string PARCELAS_QTD_DOCUMENTOS { get; set; }
        public string PARCELAS_SIT_REGISTRO { get; set; }

        public static void Execute(R0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 r0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1)
        {
            var ths = r0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}