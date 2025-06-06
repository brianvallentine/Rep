using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 : QueryBasis<R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.VG_HIST_CONT_COBER
            (NUM_CERTIFICADO ,
            NUM_PARCELA ,
            NUM_TITULO ,
            OCORR_HISTORICO ,
            COD_GRUPO_SUSEP ,
            RAMO_EMISSOR ,
            COD_MODALIDADE ,
            COD_COBERTURA ,
            VLR_PREMIO_RAMO ,
            COD_USUARIO ,
            DTH_ATUALIZACAO )
            VALUES (:NUMEROUT-NUM-CERT-VGAP ,
            :PROPOVA-NUM-PARCELA ,
            :HISCONPA-NUM-TITULO ,
            :HISCONPA-OCORR-HISTORICO,
            :H-GRUPO-SUSEP ,
            :H-COD-RAMO ,
            :VG082-COD-MODALIDADE ,
            :VG082-COD-COBERTURA ,
            :H-PREMIO-CONJ ,
            'VE2640B' ,
            CURRENT TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)} , {FieldThreatment(this.PROPOVA_NUM_PARCELA)} , {FieldThreatment(this.HISCONPA_NUM_TITULO)} , {FieldThreatment(this.HISCONPA_OCORR_HISTORICO)}, {FieldThreatment(this.H_GRUPO_SUSEP)} , {FieldThreatment(this.H_COD_RAMO)} , {FieldThreatment(this.VG082_COD_MODALIDADE)} , {FieldThreatment(this.VG082_COD_COBERTURA)} , {FieldThreatment(this.H_PREMIO_CONJ)} , 'VE2640B' , CURRENT TIMESTAMP )";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string H_GRUPO_SUSEP { get; set; }
        public string H_COD_RAMO { get; set; }
        public string VG082_COD_MODALIDADE { get; set; }
        public string VG082_COD_COBERTURA { get; set; }
        public string H_PREMIO_CONJ { get; set; }

        public static void Execute(R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 r2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1)
        {
            var ths = r2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2950_2610_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}