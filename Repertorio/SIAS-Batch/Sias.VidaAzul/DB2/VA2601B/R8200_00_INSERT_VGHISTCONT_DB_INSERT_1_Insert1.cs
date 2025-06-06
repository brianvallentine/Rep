using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 : QueryBasis<R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1>
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
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :DCLPARCELAS-VIDAZUL.NUM-PARCELA,
            :DCLCOBER-HIST-VIDAZUL.NUM-TITULO,
            :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO,
            :WHOST-GRUPO-SUSEP ,
            :WHOST-COD-RAMO ,
            :VG082-COD-MODALIDADE,
            :VG082-COD-COBERTURA,
            :WHOST-PREMIO-CONJ,
            'VA2601B' ,
            CURRENT TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.NUM_PARCELA)}, {FieldThreatment(this.NUM_TITULO)}, {FieldThreatment(this.OCORR_HISTORICO)}, {FieldThreatment(this.WHOST_GRUPO_SUSEP)} , {FieldThreatment(this.WHOST_COD_RAMO)} , {FieldThreatment(this.VG082_COD_MODALIDADE)}, {FieldThreatment(this.VG082_COD_COBERTURA)}, {FieldThreatment(this.WHOST_PREMIO_CONJ)}, 'VA2601B' , CURRENT TIMESTAMP )";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_PARCELA { get; set; }
        public string NUM_TITULO { get; set; }
        public string OCORR_HISTORICO { get; set; }
        public string WHOST_GRUPO_SUSEP { get; set; }
        public string WHOST_COD_RAMO { get; set; }
        public string VG082_COD_MODALIDADE { get; set; }
        public string VG082_COD_COBERTURA { get; set; }
        public string WHOST_PREMIO_CONJ { get; set; }

        public static void Execute(R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 r8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1)
        {
            var ths = r8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}