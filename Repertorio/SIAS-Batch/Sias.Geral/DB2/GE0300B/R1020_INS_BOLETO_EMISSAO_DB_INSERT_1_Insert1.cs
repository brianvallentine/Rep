using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0300B
{
    public class R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1 : QueryBasis<R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_BOLETO_EMISSAO
            ( NUM_OCORR_MOVTO ,
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            NUM_NOSSO_TITULO ,
            NUM_OCORR_HISTORICO,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE096-NUM-OCORR-MOVTO,
            :GE096-NUM-APOLICE,
            :GE096-NUM-ENDOSSO,
            :GE096-NUM-PARCELA,
            :GE096-NUM-NOSSO-TITULO,
            :GE096-NUM-OCORR-HISTORICO,
            :GE096-IDE-SISTEMA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_BOLETO_EMISSAO ( NUM_OCORR_MOVTO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_NOSSO_TITULO , NUM_OCORR_HISTORICO, IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE096_NUM_OCORR_MOVTO)}, {FieldThreatment(this.GE096_NUM_APOLICE)}, {FieldThreatment(this.GE096_NUM_ENDOSSO)}, {FieldThreatment(this.GE096_NUM_PARCELA)}, {FieldThreatment(this.GE096_NUM_NOSSO_TITULO)}, {FieldThreatment(this.GE096_NUM_OCORR_HISTORICO)}, {FieldThreatment(this.GE096_IDE_SISTEMA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GE096_NUM_OCORR_MOVTO { get; set; }
        public string GE096_NUM_APOLICE { get; set; }
        public string GE096_NUM_ENDOSSO { get; set; }
        public string GE096_NUM_PARCELA { get; set; }
        public string GE096_NUM_NOSSO_TITULO { get; set; }
        public string GE096_NUM_OCORR_HISTORICO { get; set; }
        public string GE096_IDE_SISTEMA { get; set; }

        public static void Execute(R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1 r1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1)
        {
            var ths = r1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}