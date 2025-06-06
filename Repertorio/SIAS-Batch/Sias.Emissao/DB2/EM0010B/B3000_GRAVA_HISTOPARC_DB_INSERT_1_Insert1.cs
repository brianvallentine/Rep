using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1 : QueryBasis<B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTOPARC
            VALUES (:HIST-NUM-APOLICE ,
            :HIST-NRENDOS ,
            :HIST-NRPARCEL ,
            :HIST-DACPARC ,
            :HIST-DTMOVTO ,
            :HIST-OPERACAO ,
            :HIST-HORAOPER ,
            :HIST-OCORHIST ,
            :HIST-PRM-TARIFARIO ,
            :HIST-VAL-DESCONTO ,
            :HIST-VLPRMLIQ ,
            :HIST-VLADIFRA ,
            :HIST-VLCUSEMI ,
            :HIST-VLIOCC ,
            :HIST-VLPRMTOT ,
            :HIST-VLPREMIO ,
            :HIST-DTVENCTO ,
            :HIST-BCOCOBR ,
            :HIST-AGECOBR ,
            :HIST-NRAVISO ,
            :HIST-NRENDOCA ,
            :HIST-SITCONTB ,
            :HIST-COD-USUARIO ,
            :HIST-RNUDOC ,
            :HIST-DTQITBCO:HIST-DTQITBCO-I,
            :HIST-COD-EMPRESA:HIST-EMPRESA-I,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTOPARC VALUES ({FieldThreatment(this.HIST_NUM_APOLICE)} , {FieldThreatment(this.HIST_NRENDOS)} , {FieldThreatment(this.HIST_NRPARCEL)} , {FieldThreatment(this.HIST_DACPARC)} , {FieldThreatment(this.HIST_DTMOVTO)} , {FieldThreatment(this.HIST_OPERACAO)} , {FieldThreatment(this.HIST_HORAOPER)} , {FieldThreatment(this.HIST_OCORHIST)} , {FieldThreatment(this.HIST_PRM_TARIFARIO)} , {FieldThreatment(this.HIST_VAL_DESCONTO)} , {FieldThreatment(this.HIST_VLPRMLIQ)} , {FieldThreatment(this.HIST_VLADIFRA)} , {FieldThreatment(this.HIST_VLCUSEMI)} , {FieldThreatment(this.HIST_VLIOCC)} , {FieldThreatment(this.HIST_VLPRMTOT)} , {FieldThreatment(this.HIST_VLPREMIO)} , {FieldThreatment(this.HIST_DTVENCTO)} , {FieldThreatment(this.HIST_BCOCOBR)} , {FieldThreatment(this.HIST_AGECOBR)} , {FieldThreatment(this.HIST_NRAVISO)} , {FieldThreatment(this.HIST_NRENDOCA)} , {FieldThreatment(this.HIST_SITCONTB)} , {FieldThreatment(this.HIST_COD_USUARIO)} , {FieldThreatment(this.HIST_RNUDOC)} ,  {FieldThreatment((this.HIST_DTQITBCO_I?.ToInt() == -1 ? null : this.HIST_DTQITBCO))},  {FieldThreatment((this.HIST_EMPRESA_I?.ToInt() == -1 ? null : this.HIST_COD_EMPRESA))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string HIST_NUM_APOLICE { get; set; }
        public string HIST_NRENDOS { get; set; }
        public string HIST_NRPARCEL { get; set; }
        public string HIST_DACPARC { get; set; }
        public string HIST_DTMOVTO { get; set; }
        public string HIST_OPERACAO { get; set; }
        public string HIST_HORAOPER { get; set; }
        public string HIST_OCORHIST { get; set; }
        public string HIST_PRM_TARIFARIO { get; set; }
        public string HIST_VAL_DESCONTO { get; set; }
        public string HIST_VLPRMLIQ { get; set; }
        public string HIST_VLADIFRA { get; set; }
        public string HIST_VLCUSEMI { get; set; }
        public string HIST_VLIOCC { get; set; }
        public string HIST_VLPRMTOT { get; set; }
        public string HIST_VLPREMIO { get; set; }
        public string HIST_DTVENCTO { get; set; }
        public string HIST_BCOCOBR { get; set; }
        public string HIST_AGECOBR { get; set; }
        public string HIST_NRAVISO { get; set; }
        public string HIST_NRENDOCA { get; set; }
        public string HIST_SITCONTB { get; set; }
        public string HIST_COD_USUARIO { get; set; }
        public string HIST_RNUDOC { get; set; }
        public string HIST_DTQITBCO { get; set; }
        public string HIST_DTQITBCO_I { get; set; }
        public string HIST_COD_EMPRESA { get; set; }
        public string HIST_EMPRESA_I { get; set; }

        public static void Execute(B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1 b3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1)
        {
            var ths = b3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}