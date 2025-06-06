using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTPRE
            VALUES (:V1CHSP-COD-EMPR ,
            :V1CHSP-CONGENER ,
            :V1CHSP-NUM-APOL ,
            :V1CHSP-NRENDOS ,
            :V1CHSP-NRPARCEL ,
            :V0CHSP-OCORHIST ,
            :V0CHSP-OPERACAO ,
            :V0CHSP-DTMOVTO ,
            :V1CHSP-TIPSGU ,
            :V1CHSP-PRM-TAR ,
            :V1CHSP-VAL-DESC ,
            :V1CHSP-VLPRMLIQ ,
            :V1CHSP-VLADIFRA ,
            :V1CHSP-VLCOMIS ,
            :V1CHSP-VLPRMTOT ,
            CURRENT TIMESTAMP ,
            :V1CHSP-DTQITBCO:VIND-DAT-QTBC,
            :V0CHSP-SIT-FINANC:VIND-SIT-FINC,
            :V0CHSP-SIT-LIBREC:VIND-SIT-LIBR,
            :V1CHSP-NUMOCOR:VIND-NUM-OCOR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES ({FieldThreatment(this.V1CHSP_COD_EMPR)} , {FieldThreatment(this.V1CHSP_CONGENER)} , {FieldThreatment(this.V1CHSP_NUM_APOL)} , {FieldThreatment(this.V1CHSP_NRENDOS)} , {FieldThreatment(this.V1CHSP_NRPARCEL)} , {FieldThreatment(this.V0CHSP_OCORHIST)} , {FieldThreatment(this.V0CHSP_OPERACAO)} , {FieldThreatment(this.V0CHSP_DTMOVTO)} , {FieldThreatment(this.V1CHSP_TIPSGU)} , {FieldThreatment(this.V1CHSP_PRM_TAR)} , {FieldThreatment(this.V1CHSP_VAL_DESC)} , {FieldThreatment(this.V1CHSP_VLPRMLIQ)} , {FieldThreatment(this.V1CHSP_VLADIFRA)} , {FieldThreatment(this.V1CHSP_VLCOMIS)} , {FieldThreatment(this.V1CHSP_VLPRMTOT)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DAT_QTBC?.ToInt() == -1 ? null : this.V1CHSP_DTQITBCO))},  {FieldThreatment((this.VIND_SIT_FINC?.ToInt() == -1 ? null : this.V0CHSP_SIT_FINANC))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V0CHSP_SIT_LIBREC))},  {FieldThreatment((this.VIND_NUM_OCOR?.ToInt() == -1 ? null : this.V1CHSP_NUMOCOR))})";

            return query;
        }
        public string V1CHSP_COD_EMPR { get; set; }
        public string V1CHSP_CONGENER { get; set; }
        public string V1CHSP_NUM_APOL { get; set; }
        public string V1CHSP_NRENDOS { get; set; }
        public string V1CHSP_NRPARCEL { get; set; }
        public string V0CHSP_OCORHIST { get; set; }
        public string V0CHSP_OPERACAO { get; set; }
        public string V0CHSP_DTMOVTO { get; set; }
        public string V1CHSP_TIPSGU { get; set; }
        public string V1CHSP_PRM_TAR { get; set; }
        public string V1CHSP_VAL_DESC { get; set; }
        public string V1CHSP_VLPRMLIQ { get; set; }
        public string V1CHSP_VLADIFRA { get; set; }
        public string V1CHSP_VLCOMIS { get; set; }
        public string V1CHSP_VLPRMTOT { get; set; }
        public string V1CHSP_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string V0CHSP_SIT_FINANC { get; set; }
        public string VIND_SIT_FINC { get; set; }
        public string V0CHSP_SIT_LIBREC { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string V1CHSP_NUMOCOR { get; set; }
        public string VIND_NUM_OCOR { get; set; }

        public static void Execute(R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1 r1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}