using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 : QueryBasis<R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_HIST_CONT_COBER
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
            VALUES (:V0HCTA-NRCERTIF,
            :V0HCTA-NRPARCEL,
            :V0HCOB-NRTIT,
            :V0HCOB-OCORHIST,
            :WHOST-GRUPO-SUSEP ,
            :WHOST-COD-RAMO ,
            :VG082-COD-MODALIDADE,
            :VG082-COD-COBERTURA,
            :WHOST-PREMIO-CONJ,
            'VA0813B' ,
            CURRENT TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0HCTA_NRPARCEL)}, {FieldThreatment(this.V0HCOB_NRTIT)}, {FieldThreatment(this.V0HCOB_OCORHIST)}, {FieldThreatment(this.WHOST_GRUPO_SUSEP)} , {FieldThreatment(this.WHOST_COD_RAMO)} , {FieldThreatment(this.VG082_COD_MODALIDADE)}, {FieldThreatment(this.VG082_COD_COBERTURA)}, {FieldThreatment(this.WHOST_PREMIO_CONJ)}, 'VA0813B' , CURRENT TIMESTAMP )";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string WHOST_GRUPO_SUSEP { get; set; }
        public string WHOST_COD_RAMO { get; set; }
        public string VG082_COD_MODALIDADE { get; set; }
        public string VG082_COD_COBERTURA { get; set; }
        public string WHOST_PREMIO_CONJ { get; set; }

        public static void Execute(R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 r7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1)
        {
            var ths = r7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}